#include <stdio.h>
#include <stdlib.h>
#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"

int		init_lua()
{
  lua_State * state;
  state = lua_open();
  luaL_openlibs(state);
  if (luaL_dofile(state, "./script/IA.lua") != 0)
    {
      fprintf(stderr, "%s\n", lua_tostring(state, -1));
      return (0);
    }
  return (1);
}
