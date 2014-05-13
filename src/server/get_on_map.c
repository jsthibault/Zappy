/*
** get_on_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:40:27 2014 lefloc_l
** Last update mar. mai 13 19:45:39 2014 lefloc_l
*/

#include "map.h"

t_case	getCase(t_map *map, int y, int x)
{
  if (x > map->width)
    x %= map->width;
  if (y > map->height)
    y %= map->height;
  return (map->map[y][x]);
}
