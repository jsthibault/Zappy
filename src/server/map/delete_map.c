/*
** delete_map.c for map in /home/loic/dev/epitech/c/Zappy/src/server/map
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 14:48:05 2014 lefloc_l
** Last update jeu. juil. 10 15:49:39 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "logger.h"

void	delete_map(t_kernel *kernel)
{
  int	i;
  int	j;

  if (!kernel->game.map)
    return ;
  for (i = 0; i < kernel->game.map->height; ++i)
  {
    for (j = 0; j < kernel->game.map->width; ++j)
    {
      list_clear(kernel->game.map->map[i][j].players);
    }
    free(kernel->game.map->map[i]);
  }
  free(kernel->game.map->map);
}
