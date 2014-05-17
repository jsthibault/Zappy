/*
** delete_map.c for map in /home/loic/dev/epitech/c/Zappy/src/server/map
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 14:48:05 2014 lefloc_l
** Last update sam. mai 17 14:52:22 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "map.h"
#include "logger.h"

extern t_map	g_map;

void	delete_map()
{
  int	i;
  int	j;

  for (i = 0; i < g_map.height; ++i)
  {
    for (j = 0; i < g_map.width; ++j)
    {
      // TODO free players list on g_map.map[i][j]

    }
    free(g_map.map[i]);
  }
 free(g_map.map);
}
