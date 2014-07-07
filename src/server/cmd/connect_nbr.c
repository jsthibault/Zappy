/*
** connect_nbr.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:40:49 2014 lefloc_l
** Last update lun. juil. 07 15:59:10 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_connect_nbr(char **av, t_client *cl, t_kernel *kernel)
{
  char		buffer[BUFFER_SIZE];
  int		nb;

  (void)av;
  // TODO -> mettre la bonne formule :)
  nb = kernel->options.max_clients - list_size(cl->player->team->players);
  sprintf(buffer, "%d", nb);
  write_socket(cl->fd, buffer);
  return (0);
}
