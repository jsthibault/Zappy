/*
** functions.c for functions in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sat Apr 19 14:20:12 2014 arnaud drain
** Last update Thu Jun 26 02:54:44 2014 arnaud drain
*/

#include <string.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include "server.h"

static void	print_bct(int fd, t_case *map_case, int x, int y)
{
  char		buf[1024];
  int		*items;

  items = map_case->inventory.items;
  sprintf(buf, "bct %d %d %d %d %d %d %d %d %d\n", x, y, items[0],
	  items[1], items[2], items[3], items[4], items[5], items[6]);
  write_socket(fd, buf);
}

static void	print_mct(int fd, t_kernel *kernel)
{
  t_pos		pos;

  for (pos.y = 0; pos.y < kernel->game.map->height; ++pos.y)
    {
      for (pos.x = 0; pos.x < kernel->game.map->width; ++pos.x)
	print_bct(fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y);
    }
}

int	graphic(char **av, t_client *cl, t_kernel *kernel)
{
  char	buf[1024];

  (void)av;
  write_socket(cl->fd, "BIENVENUE\n");
  sprintf(buf, "msz %d %d\n", (int)kernel->options.width, (int)kernel->options.height);
  write_socket(cl->fd, buf);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  write_socket(cl->fd, buf);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  write_socket(cl->fd, buf);
  print_mct(cl->fd, kernel);
  return (0);
}
