#include <erl_nif.h>

#define ERL_FUNC(name) static ERL_NIF_TERM name(ErlNifEnv *env, int argc, const ERL_NIF_TERM argv[])

#define ERL_MOD_FUNCS(name) static ErlNifFunc name[] = 

#define ERL_MOD_DEF(name, module_funcs, load) ERL_NIF_INIT(Elixir.name, module_funcs, load, NULL, NULL, NULL)

ERL_NIF_TERM enif_fetch_atom(ErlNifEnv* env, const char* name);

ERL_NIF_TERM enif_make_error(ErlNifEnv *env, const char* message);

ERL_NIF_TERM enif_make_ok(ErlNifEnv *env, const ERL_NIF_TERM result);