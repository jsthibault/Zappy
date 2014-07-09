/*
** delete_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:33:47 2014 lefloc_l
** Last update Wed Jul  9 02:56:51 2014 arnaud drain
*/

#include <stdlib.h>
#include <unistd.h>
#include "kernel.h"
#include "map.h"
#include "server.h"
#include "logger.h"

static void	delete_server(t_kernel *kernel)
{
  t_client	*client;

  while (kernel->clients)
    {
      client = kernel->clients;
      if (client->ip)
	free(client->ip);
      close(client->fd);
      kernel->clients = kernel->clients->next;
      free(client);
    }
  if (kernel->sfd)
    close(kernel->sfd);
}

static void	delete_actions(t_kernel *kernel)
{
  t_actions	*action;

  while (!list_is_empty(kernel->actions))
    {
      action = (t_actions *)list_get_front(kernel->actions);
      freetab(action->av);
      free(action);
      list_pop_front(&(kernel->actions));
    }
}

void	delete_kernel(t_kernel *kernel)
{
  if (kernel)
    {
      /* TODO : Rajouter tout les free manquants possibles */
      delete_server(kernel);
      delete_actions(kernel);
      delete_game(kernel);
      logger_message("{KERNEL} Deleted");
    }
  logger_delete();
}
