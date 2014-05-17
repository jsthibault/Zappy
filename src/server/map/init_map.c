/*
** init_map.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:16:51 2014 lefloc_l
** Last update sam. mai 17 14:46:26 2014 lefloc_l
*/

#include "logger.h"
#include "map.h"
#include "utils.h"

t_map		*g_map;

void	init_map(int width, int height)
{
  int	i;
  int	j;

  g_map = xmalloc(sizeof(t_map));
  g_map->width = width;
  g_map->height = height;
  g_map->map = (t_case **)xmalloc(sizeof(t_case *) * (height) + 1);
  for (i = 0; i < height; i++)
  {
    g_map->map[i] = (t_case *)xmalloc(sizeof(t_case) * (width + 1));
    for (j = 0; j < width; j++) {
      g_map->map[i][j].players = NULL;
    }
  }
  logger_message("{MAP} Initialisation");
}
