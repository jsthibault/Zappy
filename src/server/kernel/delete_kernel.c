/*
** delete_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:33:47 2014 lefloc_l
** Last update Thu Jul 10 01:11:22 2014 arnaud drain
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

void	delete_kernel(t_kernel *kernel)
{
  if (kernel)
    {
      delete_server(kernel);
      delete_game(kernel);
      logger_message("{KERNEL} Deleted");
    }
  logger_delete();
}
