/*
** init_player.c for player in /home/loic/dev/epitech/c/Zappy/src/server/player
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. juin 24 15:29:59 2014 lefloc_l
** Last update mer. juil. 02 23:24:59 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"

t_player	*init_player_with_position(int id, int y, int x)
{
  t_player	*player;

  if (!(player = malloc(sizeof(*player))))
    return (NULL);
  player->id = id;
  player->pv = DEFAULT_PV;
  player->pos.x = x;
  player->pos.y = y;
  player->level = 0;
  player->orientation = SOUTH;
  return (player);
}

int		get_max_id(t_kernel *kernel)
{
  int		max;
  int		pos;
  int		max_id;
  t_player	*player;

  max = list_size(kernel->game.players);
  pos = 0;
  max_id = 0;
  while (pos < max)
    {
      player = (t_player *)list_get_at(kernel->game.players, pos);
      if (player->id > max_id)
	max_id = player->id;
      ++pos;
    }
  return (max_id);
}

t_player	*init_player_with_teamname(t_kernel *kernel, char *teamname)
{
  t_team	*team;
  t_player	*player;
  t_pos		pos;

  if (!(team = find_team(kernel, teamname)))
    return (NULL);
  if (!(player = malloc(sizeof(*player))))
    return (NULL);
  player->id = get_max_id(kernel) + 1;
  player->pv = DEFAULT_PV;
  pos.x = rand() % kernel->options.width;
  pos.y = rand() % kernel->options.height;
  player->pos.x = pos.x;
  player->pos.y = pos.y;
  list_push_back(&(team->players), player);
  player->team = team;
  printf("%d %d\n", pos.x, pos.y);
  add_player_on_map(kernel, player, pos.x, pos.y);
  player->level = 0;
  player->orientation = SOUTH;
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
  list_pop_func_arg(&player->team->players, &remove_player_on_team, player);
  free(player);
}
