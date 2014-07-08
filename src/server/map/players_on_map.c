/*
** players_on_map.c for map in /home/loic/dev/epitech/c/Zappy/src/server/map
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. juin 24 15:02:11 2014 lefloc_l
<<<<<<< HEAD
** Last update mar. juil. 08 14:51:11 2014 lefloc_l
||||||| merged common ancestors
** Last update Mon Jul  7 17:58:39 2014 arnaud drain
=======
** Last update Tue Jul  8 13:04:56 2014 arnaud drain
>>>>>>> eda795d96624337ec1bf6263b968477236df0de3
*/

#include "kernel.h"
#include "logger.h"

static t_bool	find_player_to_remove(void *c, void *p)
{
  t_player	*current;
  t_player	*player;

  if (!c || !p)
    return (FALSE);
  current = (t_player *)c;
  player = (t_player *)p;
  if (current->id == player->id)
    {
      printf("true\n");
      return (TRUE);
    }
  printf("false\n");
  return (FALSE);
}

void		remove_player_on_map(t_kernel *kernel, t_player *player)
{
  t_case	*c;

  c = get_case(kernel, player->pos.y, player->pos.x);
  if (!c)
    logger_error("Invalid case on remove_player_on_map");
  if (c && list_is_empty(c->players) == FALSE)
    list_pop_func_arg(&c->players, &find_player_to_remove, player);
  if (c->players == NULL)
    printf("plus de players\n");
}

void		add_player_on_map(t_kernel *kernel, t_player *player,
    int y, int x)
{
  t_case	*c;

  c = get_case(kernel, y, x);
  if (!c)
    return;
  list_push_front(&(c->players), player);
  get_right_position(kernel, &y, &x);
  player->pos.y = y;
  player->pos.x = x;
}

void		move_player_on_map(t_kernel *kernel, t_player *player,
    int y, int x)
{
  remove_player_on_map(kernel, player);
  add_player_on_map(kernel, player, y, x);
  logger_message("move player %d: %d/%d", player->id, x, y);
}
