/*
** handleIA.c for client_ia in /home/loic/dev/epitech/c/Zappy/src/client_ia
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:35:17 2014 lefloc_l
** Last update mer. juil. 09 17:35:39 2014 lefloc_l
*/

#include <stdio.h>
#include <stdlib.h>
#include "lua.h"
#include "lualib.h"
#include "lauxlib.h"

int		init_lua()
{
  lua_State	*state;

  state = lua_open();
  luaL_openlibs(state);
  if (luaL_dofile(state, "./script/IA.lua") != 0)
    {
      fprintf(stderr, "%s\n", lua_tostring(state, -1));
      return (0);
    }
  return (1);
}
