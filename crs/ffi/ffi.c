#include "ffi.h"

ERL_NIF_TERM enif_fetch_atom(ErlNifEnv* env, const char* name) {
    ERL_NIF_TERM atom;
    if (!enif_make_existing_atom(env, name, &atom, ERL_NIF_LATIN1))
        atom = enif_make_atom(env, name);
    return atom;
}

ERL_NIF_TERM enif_make_ok(ErlNifEnv *env, const ERL_NIF_TERM result) {
    return enif_make_tuple2(env, enif_fetch_atom(env, "ok"), result);
}

ERL_NIF_TERM enif_make_error(ErlNifEnv *env, const char* message) {
    return enif_make_tuple2(env,
        enif_fetch_atom(env, "error"),
        enif_make_string(env, message, ERL_NIF_LATIN1));
}