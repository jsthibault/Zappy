/*
** init_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:16:51 2014 lefloc_l
** Last update jeu. juil. 10 16:46:41 2014 lefloc_l
*/

#include <string.h>
#include <stdlib.h>
#include "logger.h"
#include "kernel.h"
#include "utils.h"

int	random_res()
{
  int	test;

  test = rand() % 10;
  if (test < 1)
    return (2);
  if (test < 3)
    return (1);
  return (0);
}

t_bool	init_map(t_kernel *kernel, int width, int height)
{
  int	i;
  int	j;
  int	it;

  if (!(kernel->game.map = malloc(sizeof(t_map))))
    return (FALSE);
  kernel->game.map->width = width;
  kernel->game.map->height = height;
  if (!(kernel->game.map->map
        = (t_case **)malloc(sizeof(t_case *) * (height) + 1)))
    return (FALSE);
  for (i = 0; i < height; i++)
  {
    if (!(kernel->game.map->map[i]
          = (t_case *)malloc(sizeof(t_case) * (width + 1))))
      return (FALSE);
    for (j = 0; j < width; j++)
      {
	for (it = 0; it < ITEM_TYPE; ++it)
	  kernel->game.map->map[i][j].inventory.items[it] = random_res();
	kernel->game.map->map[i][j].players = NULL;
      }
  }
  logger_message("{MAP} Initialisation");
  return (TRUE);
}
