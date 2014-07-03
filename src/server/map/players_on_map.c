/*
** players_on_map.c for map in /home/loic/dev/epitech/c/Zappy/src/server/map
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. juin 24 15:02:11 2014 lefloc_l
** Last update jeu. juil. 03 16:09:41 2014 lefloc_l
*/

#include "kernel.h"
#include "logger.h"

static t_bool	find_player_to_remove(void *c, void *p)
{
  t_player	*current;
  t_player	*player;

  current = (t_player *)c;
  player = (t_player *)p;
  if (current->id == player->id)
    return (TRUE);
  return (FALSE);
}

void		remove_player_on_map(t_kernel *kernel, t_player *player)
{
  t_case	*c;

  c = get_case(kernel, player->pos.y, player->pos.x);
  list_pop_func_arg(&c->players, &find_player_to_remove, player);
}

void		add_player_on_map(t_kernel *kernel, t_player *player, int x, int y)
{
  t_case	*c;

  c = get_case(kernel, x, y);
  list_push_front(&(c->players), player);
  player->pos.y = y;
  player->pos.x = x;
}

void		move_player_on_map(t_kernel *kernel, t_player *player, int x, int y)
{
  remove_player_on_map(kernel, player);
  get_right_position(kernel, &y, &x);
  add_player_on_map(kernel, player, x, y);
  logger_message("move player %d: %d/%d", player->id, x, y);
}
