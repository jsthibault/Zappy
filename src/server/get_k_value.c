/*
** get_k_value.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  lun. juil. 07 15:50:07 2014 lefloc_l
** Last update Wed Jul  9 01:09:56 2014 arnaud drain
*/

#include "kernel.h"
#include "struct.h"

static int	abs(int val)
{
  if (val < 0)
    return (-val);
  return (val);
}

static int	calc_val(int origin, int player, int max)
{
  if (origin == player)
    return (0);
  if (origin > player && (origin - player) > (player + max - origin))
    return (player + max - origin);
  if (origin < player && (player - origin) > (origin + max - player))
    return -(origin + max - player);
  return (player - origin);
}

static int	adapt_orientation(int orientation, int val)
{
  if (orientation == EAST)
    return ((val + 1) % 8 + 1);
  if (orientation == SOUTH)
    return ((val + 3) % 8 + 1);
  if (orientation == WEST)
    return ((val + 5) % 8 + 1);
  return (val);
}

int		get_k_value(t_player *origin, t_player *player, int x_max, int y_max)
{
  t_pos		vec;

  if (origin->pos.x == player->pos.x && origin->pos.y == player->pos.y)
    return (0);
  vec.x = calc_val(origin->pos.x, player->pos.x, x_max);
  vec.y = calc_val(origin->pos.y, player->pos.y, y_max);
  if (abs(vec.x) == abs(vec.y))
    {
      if (vec.x > 0 && vec.y > 0)
	return (adapt_orientation(player->orientation, 2));
      if (vec.x < 0 && vec.y < 0)
	return (adapt_orientation(player->orientation, 6));
      if (vec.x < 0)
	return (adapt_orientation(player->orientation, 8));
      return (adapt_orientation(player->orientation, 4));
    }
  if (vec.y > 0 && abs(vec.y) > abs(vec.x))
    return (adapt_orientation(player->orientation, 1));
  if (vec.x < 0 && abs(vec.x) > abs(vec.y))
    return (adapt_orientation(player->orientation, 3));
  if (vec.y < 0 && abs(vec.y) > abs(vec.x))
    return (adapt_orientation(player->orientation, 5));
  return (adapt_orientation(player->orientation, 7));
}
