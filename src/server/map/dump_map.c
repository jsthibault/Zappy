/*
** dump_map.c for dump_map in /home/drain_a/rendu/Zappy
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Wed Jun 25 23:33:23 2014 arnaud drain
** Last update Thu Jun 26 02:18:16 2014 arnaud drain
*/

#include "map.h"

void		dump_map(t_kernel *kernel)
{
  int		x;
  int		y;
  t_case	*map_case;

  for (x = 0; x < kernel->game.map->height; ++x)
  {
    for (y = 0; y < kernel->game.map->width; ++y)
    {
      map_case = get_case(kernel, y, x);
      if (list_size(map_case->players))
	printf("%d", (int)list_size(map_case->players));
      else
	printf(".");
    }
    printf("\n");
  }
}
