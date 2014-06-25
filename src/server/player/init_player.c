/*
** init_player->c for player in /home/loic/dev/epitech/c/Zappy/src/server/player
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. juin 24 15:29:59 2014 lefloc_l
** Last update Wed Jun 25 10:45:13 2014 arnaud drain
*/

#include <stdlib.h>
#include "kernel.h"

t_player	*init_player(int id, int y, int x)
{
  t_player	*player;

  if (!(player = malloc(sizeof(*player))))
    return (NULL);
  player->id = id;
  player->pv = DEFAULT_PV;
  player->pos.x = x;
  player->pos.y = y;
  return (player);
}

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

void	remove_player(t_player *player)
{
  list_pop_func_arg(player->team->players, &remove_player_on_team, player);
  free(player);
}
