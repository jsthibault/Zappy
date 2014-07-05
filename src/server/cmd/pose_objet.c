/*
** pose_objet.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:19 2014 lefloc_l
** Last update sam. juil. 05 15:46:25 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "kernel.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_pose_objet(char **av, t_client *cl, t_kernel *kernel)
{
  t_case	*c;
  int		obj;

  (void)av;
  (void)kernel;
  if (av_length(av) != 2)
    return (-1);
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  obj = atoi(av[1]);
  if (cl->player->inventory.items[obj] > 0)
  {
    c->inventory.items[obj]++;
    cl->player->inventory.items[obj]--;
    write_socket(cl->fd, "ok\n");
    send_pose_to_graphic(kernel, cl->player, cl->player->inventory.items[obj]);
  }
  else
  {
    write_socket(cl->fd, "ko\n");
  }
  return (0);
}
