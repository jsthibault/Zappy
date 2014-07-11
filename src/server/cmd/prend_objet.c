/*
** prend_objet.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:04 2014 lefloc_l
** Last update Fri Jul 11 03:18:28 2014 arnaud drain
*/

#include <stdlib.h>
#include <string.h>
#include "client_action.h"
#include "server.h"
#include "kernel.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		atoi_objet(char *objet)
{
  int		i;
  static char	*value[ITEM_TYPE] =
    {
      "nourriture",
      "linemate",
      "deraumere",
      "sibur",
      "mendiane",
      "phiras",
      "thystame",
    };

  i = 0;
  while (i < ITEM_TYPE)
    {
      if (!strcmp(objet, value[i]))
	return (i);
      ++i;
    }
  return (-1);
}

int		cmd_prend_objet(char **av, t_client *cl, t_kernel *kernel)
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
  if (c->inventory.items[obj] > 0)
  {
    c->inventory.items[obj]--;
    cl->player->inventory.items[obj]++;
    write_socket(cl->fd, "ok\n");
    send_prend_to_graphic(kernel, cl->player, obj);
  }
  else
    write_socket(cl->fd, "ko\n");
  return (0);
}
