/*
** mct.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:47:55 2014 lefloc_l
** Last update jeu. juil. 10 23:31:43 2014 lefloc_l
*/

#include "kernel.h"
#include "client_action.h"

int	print_mct(int fd, t_kernel *kernel)
{
  t_pos	pos;

  for (pos.y = 0; pos.y < kernel->game.map->height; ++pos.y)
    {
      for (pos.x = 0; pos.x < kernel->game.map->width; ++pos.x)
	{
	  if (print_bct(fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y) <= 0)
	    return (-1);
	}
    }
  printf("end\n");
  return (0);
}

int	mct(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  return (0);
}

