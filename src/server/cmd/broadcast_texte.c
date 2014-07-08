/*
** broadcast_texte.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:57 2014 lefloc_l
** Last update Tue Jul  8 15:57:04 2014 arnaud drain
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

static void	send_to_clients(t_kernel *kernel, char *buffer, int fd)
{
  t_client	*list;

  list = kernel->clients;
  while (list)
  {
    if (list->fd != fd)
      write_socket(list->fd, buffer);
    list = list->next;
  }
}

int		cmd_broadcast_texte(char **av, t_client *cl, t_kernel *kernel)
{
  t_client	*list;
  char		buffer[BUFFER_SIZE];
  int		i;

  if (av_length(av) < 2)
    return (0);
  list = kernel->clients;
  while (list)
    {
      sprintf(buffer, "message %d,", get_k_value(cl->player, list->player));
      if (list->fd != cl->fd)
	write_socket(list->fd, buffer);
      list = list->next;
    } 
  for (i = 1; av[i]; i++)
    send_to_clients(kernel, av[i], cl->fd);
  send_to_clients(kernel, "\n", cl->fd);
  return (0);
}
