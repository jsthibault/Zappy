/*
** broadcast_texte.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:57 2014 lefloc_l
** Last update lun. juil. 07 15:51:33 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

static void	send_to_clients(t_kernel *kernel, char *buffer,
    t_player *origin)
{
  static t_bool	first = TRUE;
  t_node	*node;
  t_client	*list;
  char		buffer2[BUFFER_SIZE];

  list = kernel->clients;
  while (list)
  {
    if (first == TRUE)
    {
      sprintf(buffer2, "message %d,", get_k_value(origin, list->player));
      write_socket(list->fd, buffer2);
      first = FALSE;
    }
    write_socket(list->fd, buffer);
    list = list->next;
  }
}

int		cmd_broadcast_texte(char **av, t_client *cl, t_kernel *kernel)
{
  char		buffer[BUFFER_SIZE];
  int		i;

  (void)av;
  for (i = 1; av[i]; i++)
  {
    send_to_clients(kernel, av[i], cl->player);
  }
  send_to_clients(kernel, "\n", cl->player);
  return (0);
}
