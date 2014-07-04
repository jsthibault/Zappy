/*
** send_to_graphic.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. juil. 04 15:38:31 2014 lefloc_l
** Last update ven. juil. 04 16:06:26 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"

void	send_ppo_to_graphic(t_kernel *kernel, t_client *client)
{
  char	buffer[BUFFER_SIZE];

  sprintf(buffer, "ppo #%d %d %d %d\n", client->player->id, client->player->pos.x,
      client->player->pos.y, client->player->orientation);
  write_all_graphic(kernel, buffer);
}

void		send_prend_to_graphic(t_kernel *kernel, t_client *cl, int item)
{
  char		buffer[BUFFER_SIZE];
  int		*items;
  t_case	*map_case;

  map_case = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  items = cl->player->inventory.items;
  sprintf(buffer, "pgt #%d %d\n", cl->player->id, item);
  sprintf(buffer, "%spin #%d %d %d %d %d %d %d %d %d %d\n",
      buffer, cl->player->id, cl->player->pos.x, cl->player->pos.y, items[0],
      items[1], items[2], items[3], items[4], items[5], items[6]);
  items = map_case->inventory.items;
  sprintf(buffer, "%sbct %d %d %d %d %d %d %d %d %d\n", buffer,
      cl->player->pos.x, cl->player->pos.y, items[0], items[1], items[2],
      items[3], items[4], items[5], items[6]);
  write_all_graphic(kernel, buffer);
}
