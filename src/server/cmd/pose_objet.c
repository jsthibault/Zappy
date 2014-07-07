/*
** pose_objet.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:19 2014 lefloc_l
** Last update Mon Jul  7 17:06:46 2014 arnaud drain
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

  if (av_length(av) != 2)
    return (-1);
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  if ((obj = atoi_objet(av[1])) < 0)
    {
      write_socket(cl->fd, "ko\n");
      return (0);
    }
  if (cl->player->inventory.items[obj] > 0)
  {
    c->inventory.items[obj]++;
    cl->player->inventory.items[obj]--;
    write_socket(cl->fd, "ok\n");
    send_pose_to_graphic(kernel, cl->player, cl->player->inventory.items[obj]);
  }
  else
    write_socket(cl->fd, "ko\n");
  return (0);
}
