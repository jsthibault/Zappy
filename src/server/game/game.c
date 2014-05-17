/*
** game.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:22:33 2014 lefloc_l
** Last update sam. mai 17 17:46:52 2014 lefloc_l
*/

#include "kernel.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void	delete_game()
{
  logger_message("{GAME} Delete");

  list_foreach(g_kernel->game->teams, delete_team);
  free(g_kernel->game);
}

void	init_game()
{
  g_kernel->game = xmalloc(sizeof(t_game));
  init_team();
}
