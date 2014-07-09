/*
** broadcast_texte.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:39:16 2014 lefloc_l
** Last update mer. juil. 09 17:39:20 2014 lefloc_l
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
    if (list->player && list->fd != fd)
      write_socket(list->fd, buffer);
    list = list->next;
  }
}

static void	send_message_to_client(t_kernel *kernel, t_client *cl)
{
  t_client	*list;
  char		buffer[BUFFER_SIZE];

  list = kernel->clients;
  while (list)
    {
      if (list->player && list->fd != cl->fd)
	{
	  sprintf(buffer, "message %d,",
		  get_k_value(cl->player, list->player, kernel->game.map->width,
			      kernel->game.map->height));
	  write_socket(list->fd, buffer);
	}
      list = list->next;
    }
}

int		cmd_broadcast_texte(char **av, t_client *cl, t_kernel *kernel)
{
  int		i;

  if (av_length(av) < 2)
    return (0);
  send_message_to_client(kernel, cl);
  for (i = 1; av[i]; i++)
    {
      if (i > 1)
	send_to_clients(kernel, " ", cl->fd);
      send_to_clients(kernel, av[i], cl->fd);
    }
  send_to_clients(kernel, "\n", cl->fd);
  write_socket(cl->fd, "ok\n");
  return (0);
}
