/*
** get_on_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:40:27 2014 lefloc_l
** Last update sam. mai 17 14:44:48 2014 lefloc_l
*/

#include "map.h"
#include "utils.h"

extern t_map	*g_map;

/*
** return a map's case. The world is a sphere !
** First: manage negative numbers
** Second: manage to big numbers
*/
t_case	*get_case(int y, int x)
{
  x = (x < 0 ? g_map->width - (x % g_map->width) : x);
  y = (y < 0 ? g_map->height - (y % g_map->width) : y);
  x = (x > g_map->width ? x % g_map->width : x);
  y = (y > g_map->height ? y % g_map->height : y);
  return (&g_map->map[y][x]);
}
