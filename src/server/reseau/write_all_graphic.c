/*
** write_all_graphic.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:47:41 2014 lefloc_l
** Last update mer. juil. 09 17:48:01 2014 lefloc_l
*/

#include "kernel.h"
#include "utils.h"
#include "client_action.h"

void		write_all_graphic(t_kernel *kernel, char *str)
{
  t_client	*client;

  client = kernel->clients;
  while (client)
    {
      if (client->graphic)
	write_socket(client->fd, str);
      client = client->next;
    }
}


