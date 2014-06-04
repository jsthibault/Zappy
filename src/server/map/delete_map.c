/*
** delete_map.c for map in /home/loic/dev/epitech/c/Zappy/src/server/map
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 14:48:05 2014 lefloc_l
** Last update sam. mai 17 19:38:53 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void	delete_map()
{
  int	i;
  int	j;

  for (i = 0; i < g_kernel->game->map->height; ++i)
  {
    for (j = 0; j < g_kernel->game->map->width; ++j)
    {
      list_delete(g_kernel->game->map->map[i][j].players);
    }
    free(g_kernel->game->map->map[i]);
  }
 free(g_kernel->game->map->map);
}
