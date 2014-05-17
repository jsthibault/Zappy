/*
** game.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:22:33 2014 lefloc_l
** Last update sam. mai 17 18:18:49 2014 lefloc_l
*/

#include "kernel.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void	delete_game()
{
  list_foreach(g_kernel->game->teams, delete_team);
  list_delete(g_kernel->game->teams);
  free(g_kernel->game);
  logger_message("{GAME} Deleted");
}

void	init_game()
{
  g_kernel->game = xmalloc(sizeof(t_game));
  init_team();
}
