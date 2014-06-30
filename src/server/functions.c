/*
** functions.c for functions in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sat Apr 19 14:20:12 2014 arnaud drain
** Last update Fri Jun 27 20:57:53 2014 arnaud drain
*/

#include <string.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include "server.h"

static int	print_bct(int fd, t_case *map_case, int x, int y)
{
  char		buf[1024];
  int		*items;

  items = map_case->inventory.items;
  sprintf(buf, "bct %d %d %d %d %d %d %d %d %d\n", x, y, items[0],
	  items[1], items[2], items[3], items[4], items[5], items[6]);
  return (write_socket(fd, buf));
}

static int	print_mct(int fd, t_kernel *kernel)
{
  t_pos		pos;

  for (pos.y = 0; pos.y < kernel->game.map->height; ++pos.y)
    {
      for (pos.x = 0; pos.x < kernel->game.map->width; ++pos.x)
	{
	  int test;
	  test = print_bct(fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y);
	  printf("x : %d y : %d %d\n", pos.x, pos.y, test);
	  if (test <= 0)
	    return (-1);
	}
    }
  return (0);
}

int	graphic(char **av, t_client *cl, t_kernel *kernel)
{
  char	buf[1024];

  (void)av;
  if (cl->player)
    return (0);
  cl->graphic = TRUE;
  if (write_socket(cl->fd, "BIENVENUE\n") <= 0)
    return (1);
  sprintf(buf, "msz %d %d\n", (int)kernel->options.width, (int)kernel->options.height);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  printf("the end\n");
  return (0);
}
