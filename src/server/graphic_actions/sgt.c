/*
** sgt.c for graphic_actions in /home/loic/dev/epitech/c/Zappy/src/server/graphic_actions
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 23:20:18 2014 lefloc_l
** Last update jeu. juil. 10 23:20:30 2014 lefloc_l
*/

#include "kernel.h"
#include "client_action.h"

int		sgt(char **av, t_client *cl, t_kernel *kernel)
{
  char          buff[BUFFER_SIZE];

  (void)av;
  sprintf(buff, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
