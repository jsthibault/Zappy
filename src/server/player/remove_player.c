/*
** remove_player.c for player in /home/loic/dev/epitech/c/Zappy/src/server/player
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:44:35 2014 lefloc_l
** Last update Thu Jul 10 01:12:38 2014 arnaud drain
*/

#include <stdlib.h>
#include <string.h>
#include "kernel.h"
#include "client_action.h"
#include "logger.h"

static t_bool	remove_player_on_team(void *c, void *p)
{
  t_player	*player;
  t_player	*current;

  current = (t_player *)c;
  player = (t_player *)p;
  if (player->id == current->id)
    return (TRUE);
  return (FALSE);
}

static void	delete_actions(t_list *actions)
{
  t_actions	*action;

  while (!list_is_empty(actions))
    {
      action = (t_actions *)list_get_front(actions);
      freetab(action->av);
      free(action);
      list_pop_front(&actions);
    }
}

void	remove_player(t_kernel *kernel, t_player *player)
{
  send_deconnexion_to_graphic(kernel, player);
  list_pop_func_arg(&player->team->players, &remove_player_on_team, player);
  if (!(player->from_egg))
    ++(player->team->place_left);
  delete_actions(player->actions);
  remove_player_on_map(kernel, player);
  list_pop_func_arg(&kernel->game.players, &remove_player_on_team, player);
  free(player);
}
