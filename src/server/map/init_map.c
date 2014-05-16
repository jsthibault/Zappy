/*
** init_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:16:51 2014 lefloc_l
** Last update ven. mai 16 17:51:36 2014 lefloc_l
*/

#include "map.h"
#include "utils.h"

extern t_map		g_map;

void	init_map(int width, int height)
{
  int	i;
  int	j;

  g_map.width = width;
  g_map.height = height;
  g_map.map = xmalloc(sizeof(t_case) * height);
  for (i = 0; i < g_map.height; ++i)
  {
    g_map.map[i] = xmalloc(sizeof(t_case *) * width);
    for (j = 0; j < g_map.width; ++j) {
      g_map.map[j][i].players = NULL;
    }
  }
}
