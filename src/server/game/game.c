/*
** game.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:22:33 2014 lefloc_l
** Last update jeu. juil. 10 16:26:21 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "logger.h"

void	delete_game(t_kernel *kernel)
{
  //free des oeufs ;)
  if (kernel->game.teams)
  {
    list_foreach(kernel->game.teams, delete_team);
    list_delete(kernel->game.teams);
  }
  if (kernel->game.players)
  {
    list_foreach(kernel->game.players, delete_player);
    list_delete(kernel->game.players);
  }
  delete_map(kernel);
  logger_message("{GAME} Deleted");
}

t_bool	init_game(t_kernel *kernel)
{
  logger_message("{GAME} Initialisation");
  init_map(kernel, kernel->options.width, kernel->options.height);
  if (FALSE == init_team(kernel))
    return (FALSE);
  return (TRUE);
}

t_bool	pre_fill_game(t_kernel *kernel)
{
  kernel->game.teams = NULL;
  kernel->game.eggs = NULL;
  if (!(kernel->game.players = list_create()))
    return (FALSE);
  kernel->game.map = NULL;
  return (TRUE);
}
