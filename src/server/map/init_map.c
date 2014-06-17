/*
** init_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:16:51 2014 lefloc_l
** Last update Tue Jun 17 15:48:42 2014 arnaud drain
*/

#include "logger.h"
#include "kernel.h"
#include "utils.h"

void	init_map(t_kernel *kernel, int width, int height)
{
  int	i;
  int	j;

  kernel->game.map = xmalloc(sizeof(t_map));
  kernel->game.map->width = width;
  kernel->game.map->height = height;
  kernel->game.map->map = (t_case **)xmalloc(sizeof(t_case *) * (height) + 1);
  for (i = 0; i < height; i++)
  {
    kernel->game.map->map[i] = (t_case *)xmalloc(sizeof(t_case) * (width + 1));
    for (j = 0; j < width; j++) {
      kernel->game.map->map[i][j].players = NULL;
    }
  }
  logger_message("{MAP} Initialisation");
}
