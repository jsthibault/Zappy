/*
** get_on_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:40:27 2014 lefloc_l
** Last update Tue Jun 17 15:52:13 2014 arnaud drain
*/

#include "kernel.h"
#include "utils.h"

/*
** return a map's case. The world is a sphere !
** First: manage negative numbers
** Second: manage to big numbers
*/
t_case	*get_case(t_kernel *kernel, int y, int x)
{
  t_map	*map;

  map = kernel->game.map;
  x = (x < 0 ? map->width - (x % map->width) : x);
  y = (y < 0 ? map->height - (y % map->width) : y);
  x = (x > map->width ? x % map->width : x);
  y = (y > map->height ? y % map->height : y);
  return (&map->map[y][x]);
}
