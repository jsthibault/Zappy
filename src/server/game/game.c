/*
** game.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:22:33 2014 lefloc_l
** Last update Thu Jun 26 01:38:55 2014 arnaud drain
*/

#include <stdlib.h>
#include "kernel.h"
#include "logger.h"

void	delete_game(t_kernel *kernel)
{
  if (kernel->game.teams)
  {
    list_foreach(kernel->game.teams, delete_team);
    list_delete(kernel->game.teams);
  }
  if (kernel->game.players)
  {
    list_foreach(kernel->game.teams, delete_player);
    list_delete(kernel->game.players);
  }
  logger_message("{GAME} Deleted");
}

void	init_game(t_kernel *kernel)
{
  logger_message("{GAME} Initialisation");
  init_map(kernel, kernel->options.width, kernel->options.height);
  init_team(kernel);
}

void	pre_fill_game(t_kernel *kernel)
{
  kernel->game.teams = NULL;
  kernel->game.players = list_create();
  kernel->game.map = NULL;
}
