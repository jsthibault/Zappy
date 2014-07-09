/*
** remove_player.c for player in /home/loic/dev/epitech/c/Zappy/src/server/player
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:44:35 2014 lefloc_l
** Last update Wed Jul  9 21:40:51 2014 arnaud drain
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

static t_bool	remove_action_from_player(void *c, void *p)
{
  t_player	*player;
  t_actions	*action;

  player = (t_player *)p;
  action = (t_actions *)c;
  if (player->id == action->client->player->id)
    {
      freetab(action->av);
      free(action);
      return (TRUE);
    }
  return (FALSE);
}

void	remove_player(t_kernel *kernel, t_player *player)
{
  send_deconnexion_to_graphic(kernel, player);
  list_pop_func_arg(&player->team->players, &remove_player_on_team, player);
  if (!(player->from_egg))
    ++(player->team->place_left);
  list_pop_func_arg(&kernel->actions, &remove_action_from_player, player);
  remove_player_on_map(kernel, player);
  list_pop_func_arg(&kernel->game.players, &remove_player_on_team, player);
  free(player);
}
