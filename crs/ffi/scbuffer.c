#include "ffi.h"
#include <stdint.h>
#include <string.h>
#include <stdbool.h>

static ErlNifResourceType *SCBUFFER;
typedef uint32_t buf_int_t;
typedef unsigned char* buf_data_t;

typedef struct {
    buf_int_t max;
    buf_int_t wpos;
    buf_int_t rpos;
    buf_data_t data;
} sc_buffer_t;

#define MIN(a,b) (((a)<(b))?(a):(b))

sc_buffer_t* sc_buffer_new(ErlNifEnv* env, const buf_int_t max) {
    sc_buffer_t* buf = (sc_buffer_t*)enif_alloc_resource(SCBUFFER, sizeof(sc_buffer_t));
    buf->max = max;
    buf->data = NULL;
    buf->wpos = buf->rpos = 0;
    return buf;
}

buf_int_t sc_buffer_read(sc_buffer_t* buf, buf_data_t output, buf_int_t size) {
    if (!buf || !size || buf->rpos >= buf->wpos)
        return 0;
    size = MIN(size, buf->wpos - buf->rpos);
    memcpy(output, buf->data + buf->rpos, size);
    buf->rpos += size;
    return size;
}

void sc_buffer_write(sc_buffer_t* buf, const buf_data_t data, const buf_int_t size) {
    if (!buf || !data || !size)
        return;
    
    // first write, create the buffer
    if (!buf->data) {
        buf->wpos = buf->max = size;
        buf->data = (buf_data_t)enif_alloc(buf->max);
    }
    
    // reposition contents to not waste front bytes
    if (buf->rpos) {
        memmove(buf->data, buf->data + buf->rpos, buf->wpos - buf->rpos);
        buf->wpos -= buf->rpos;
        buf->rpos = 0;
    }

    // resize buffer if too small
    if (buf->wpos + size > buf->max) {
        buf->max = (buf->wpos + size) * 13 / 10;
        buf->data = (buf_data_t)enif_realloc(buf->data, buf->max);
    }

    memcpy(buf->data + buf->wpos, data, size);
    buf->wpos += size;
}

/// NIF Interface 

ERL_FUNC(new) {
    ERL_NIF_TERM buf;
    unsigned int size;
    sc_buffer_t* buffer;

    if (!enif_get_uint(env, argv[0], &size))
        return enif_make_badarg(env);
    
    buffer = sc_buffer_new(env, size);
    buf = enif_make_resource(env, buffer);
    enif_release_resource(buffer);
    return buf;
}
ERL_FUNC(new0) {
    const ERL_NIF_TERM args[] = { enif_make_uint(env, 0) };
    return new(env, 1, args);
}

ERL_FUNC(from) {
    ERL_NIF_TERM buf;
    ErlNifBinary bytes;
    sc_buffer_t* buffer;

    if (!enif_inspect_binary(env, argv[0], &bytes))
        return enif_make_badarg(env);

    buffer = sc_buffer_new(env, bytes.size);
    sc_buffer_write(buffer, (const buf_data_t)bytes.data, bytes.size);

    buf = enif_make_resource(env, buffer);
    enif_release_resource(buffer);
    return buf;
}

/// 24 bit types

#define i24struct(name, type) typedef struct { type b8; type b16; type b24; } name
#define i24num(i24) ( (i24).b8 | ((i24).b16 << 8) | ((i24).b24 << 16) )
i24struct(int24_t, int8_t);
i24struct(uint24_t, uint8_t);

/// Read Functions

#define ERL_READ_SETUP(type)                                                  \
    type num;                                                                 \
    sc_buffer_t* buffer;                                                      \
    if (!enif_get_resource(env, argv[0], SCBUFFER, (void**)&buffer))          \
        return enif_make_badarg(env);                                         \
    if (sc_buffer_read(buffer, (buf_data_t)&num, sizeof(num)) != sizeof(num)) \
        return enif_make_error(env, "Not enough data in SCBuffer");

#define ERL_READ(name, type, is_unsigned) ERL_FUNC(name) { \
    ERL_READ_SETUP(type);                                  \
    return enif_make_ok(env, (is_unsigned) ?               \
        enif_make_uint64(env, num) :                       \
        enif_make_int64(env, num));                        \
}

#define ERL_READ_DATA(name, type, after) ERL_FUNC(name) {                 \
    ErlNifBinary binary;                                                  \
    binary.data = NULL;                                                   \
    ERL_READ_SETUP(type);                                                 \
    if (num < 0)                                                          \
        return enif_make_error(env, "Invalid length read from SCBuffer"); \
    if (sc_buffer_read(buffer, (buf_data_t)binary.data, num) != num)      \
        return enif_make_error(env, "Not enough data in SCBuffer");       \
    binary.size = num;                                                    \
    after;                                                                \
}

#define ERL_READ_24(name, type, is_unsigned) ERL_FUNC(name) { \
    ERL_READ_SETUP(type);                                     \
    return enif_make_ok(env, (is_unsigned) ?                  \
        enif_make_uint(env, i24num(num)) :                    \
        enif_make_int(env, i24num(num)));                     \
}

ERL_READ(read_int16, int16_t, false)
ERL_READ(read_int32, int32_t, false)
ERL_READ_24(read_int24, int24_t, false)
ERL_READ(read_int64, int64_t, false)
ERL_READ(read_uint16, uint16_t, true)
ERL_READ_24(read_uint24, uint24_t, true)
ERL_READ(read_uint32, uint32_t, true)
ERL_READ(read_uint64, uint64_t, true)
ERL_READ_DATA(read_bytes, int64_t, return enif_make_binary(env, &binary))
ERL_READ_DATA(read_string, int64_t, return enif_make_string_len(
    env, (const char*)binary.data, binary.size, ERL_NIF_LATIN1))

/// Module functions

ERL_MOD_FUNCS(reader_funcs) {
    { "new", 1, new },
    { "new", 0, new0 },
    { "from", 1, from },

    { "read", 1, read_bytes },
    { "readstr", 1, read_string },
    { "read16", 1, read_int16 },
    { "read24", 1, read_int24 },
    { "read32", 1, read_int32 },
    { "read64", 1, read_int64 },
    { "readu16", 1, read_uint16 },
    { "readu24", 1, read_uint24 },
    { "readu32", 1, read_uint32 },
    { "readu64", 1, read_uint64 }
};

static void cleanup(ErlNifEnv *env, void *obj) {}
static int load(ErlNifEnv *env, void **priv_data, ERL_NIF_TERM load_info) {
    SCBUFFER = enif_open_resource_type(env, NULL, "scbuffer", &cleanup, ERL_NIF_RT_CREATE, 0);
    return SCBUFFER ? 0 : -1;
}

ERL_MOD_DEF(Crs.Utils.SCBuffer, reader_funcs, load)