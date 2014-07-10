/*
** sst.c for graphic_actions in /home/loic/dev/epitech/c/Zappy/src/server/graphic_actions
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 23:20:47 2014 lefloc_l
** Last update jeu. juil. 10 23:34:19 2014 lefloc_l
*/

#include <stdio.h>
#include <stdlib.h>
#include "kernel.h"
#include "client_action.h"

int	sst(char **av, t_client *cl, t_kernel *kernel)
{
  char	buff[BUFFER_SIZE];
  int	new_delai;

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  new_delai = atoi(av[1]);
  if (new_delai <= 0)
    return (sbp(cl->fd));
  kernel->options.delai = new_delai;
  sprintf(buff, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
