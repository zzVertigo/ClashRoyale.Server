#include "ffi.h"
#include <stdint.h>
#include <string.h>

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

ERL_MOD_FUNCS(reader_funcs) {
    { "new", 1, new },
    { "new", 0, new0 },
    { "from", 1, from }
};

static void cleanup(ErlNifEnv *env, void *obj) {}
static int load(ErlNifEnv *env, void **priv_data, ERL_NIF_TERM load_info) {
    SCBUFFER = enif_open_resource_type(env, NULL, "scbuffer", &cleanup, ERL_NIF_RT_CREATE, 0);
    return SCBUFFER ? 0 : -1;
}

ERL_MOD_DEF(Crs.Utils.SCBuffer, reader_funcs, load)