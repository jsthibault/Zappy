/*
** droite.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:06 2014 lefloc_l
** Last update ven. juil. 04 15:47:29 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_droite(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  (void)kernel;

  if (cl->player->orientation == 4)
    cl->player->orientation = 0;
  else
    cl->player->orientation++;
  write_socket(cl->fd, "ok\n");
  send_ppo_to_graphic(kernel, cl);
  return (0);
}
