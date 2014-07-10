/*
** connect_nbr.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:40:49 2014 lefloc_l
** Last update jeu. juil. 10 23:37:10 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int	cmd_connect_nbr(char **av, t_client *cl, t_kernel *kernel)
{
  char	buffer[BUFFER_SIZE];

  (void)av;
  (void)kernel;
  sprintf(buffer, "%d\n", cl->player->team->place_left);
  write_socket(cl->fd, buffer);
  return (0);
}
