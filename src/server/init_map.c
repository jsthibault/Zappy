/*
** init_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:16:51 2014 lefloc_l
** Last update ven. mai 16 14:18:13 2014 lefloc_l
*/

#include "map.h"
#include "utils.h"

t_map		init_map(int width, int height)
{
  t_map		map;
  size_t	i;
  size_t	j;

  map.width = width;
  map.height = height;
  map.map = xmalloc(sizeof(t_case) * height);
  for (i = 0; i < map.height; ++i)
  {
    map.map[i] = xmalloc(sizeof(t_case *) * width);
    for (j = 0; j < map.width; ++j) {
      map.map[j][i].nb_food = 0;
      map.map[j][i].players = NULL;
    }
  }
}
