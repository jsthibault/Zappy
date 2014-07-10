/*
** msz.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:45:49 2014 lefloc_l
** Last update jeu. juil. 10 23:32:43 2014 lefloc_l
*/

#include "kernel.h"
#include "server.h"

int	msz(char **av, t_client *cl, t_kernel *kernel)
{
  char	buff[BUFFER_SIZE];
  int	x;
  int	y;

  (void)av;
  x = kernel->options.width;
  y = kernel->options.height;
  sprintf(buff, "msz %d %d\n", x, y);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
