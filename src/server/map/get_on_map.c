/*
** get_on_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:40:27 2014 lefloc_l
** Last update Sun Jul  6 14:15:36 2014 arnaud drain
*/

#include "kernel.h"
#include "utils.h"
#include "logger.h"

/*
** return a map's case. The world is a sphere !
** First: manage negative numbers
** Second: manage to big numbers
*/
t_case	*get_case(t_kernel *kernel, int y, int x)
{
  t_map	*map;

  map = kernel->game.map;
  get_right_position(kernel, &y, &x);
  return (&map->map[y][x]);
}

void	get_right_position(t_kernel *kernel, int *y, int *x)
{
  t_map	*map;

  map = kernel->game.map;
  while (*x < 0)
    *x += map->width;
  while (*y < 0)
    *y += map->height;
  *x = ((*x >= map->width - 1) ? (*x % map->width) : *x);
  *y = ((*y >= map->height - 1) ? (*y % map->height) : *y);
}
