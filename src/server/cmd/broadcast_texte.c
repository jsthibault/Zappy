/*
** broadcast_texte.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:57 2014 lefloc_l
** Last update lun. juil. 07 15:34:00 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

static void	send_to_clients(t_kernel *kernel, char *buffer)
{
  t_node	*node;
  t_client	*list;

  list = kernel->clients;
  while (list)
  {
    write_socket(list->fd, buffer);
    list = list->next;
  }
}

int		cmd_broadcast_texte(char **av, t_client *cl, t_kernel *kernel)
{
  char		buffer[BUFFER_SIZE];
  int		i;

  (void)av;
  sprintf(buffer, "message %d,", cl->player->orientation);
  send_to_clients(kernel, buffer);
  for (i = 1; av[i]; i++)
  {
    send_to_clients(kernel, av[i]);
  }
  send_to_clients(kernel, "\n");
  return (0);
}
