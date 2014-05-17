/*
** game.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:22:33 2014 lefloc_l
** Last update sam. mai 17 18:59:21 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void	delete_game()
{
  if (g_kernel->game->teams)
  {
    list_foreach(g_kernel->game->teams, delete_team);
    list_delete(g_kernel->game->teams);
  }
  if (g_kernel->game->players)
  {
    list_foreach(g_kernel->game->teams, delete_player);
    list_delete(g_kernel->game->players);
  }
  free(g_kernel->game);
  logger_message("{GAME} Deleted");
}

void	init_game()
{
  g_kernel->game = xmalloc(sizeof(t_game));
  g_kernel->game->players = NULL;
  init_team();
}
