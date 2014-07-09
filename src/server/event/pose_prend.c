/*
** pose_prend.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:42:14 2014 lefloc_l
** Last update mer. juil. 09 17:42:36 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "enum.h"

static void	prend_pose(t_kernel *kernel, t_player *player, int item,
    char *cmd)
{
  char		buffer[BUFFER_SIZE];
  int		*items;
  t_case	*map_case;

  map_case = get_case(kernel, player->pos.y, player->pos.x);
  items = player->inventory.items;
  sprintf(buffer, "%s %d %d\n", cmd, player->id, item);
  sprintf(buffer, "%spin %d %d %d %d %d %d %d %d %d %d\n",
      buffer, player->id, player->pos.x, player->pos.y, items[0],
      items[1], items[2], items[3], items[4], items[5], items[6]);
  items = map_case->inventory.items;
  sprintf(buffer, "%sbct %d %d %d %d %d %d %d %d %d\n", buffer,
      player->pos.x, player->pos.y, items[0], items[1], items[2],
      items[3], items[4], items[5], items[6]);
  write_all_graphic(kernel, buffer);
}

void		send_prend_to_graphic(t_kernel *kernel, t_player *player,
    int item)
{
  prend_pose(kernel, player, item, "pgt");
}

void		send_pose_to_graphic(t_kernel *kernel, t_player *player,
    int item)
{
  prend_pose(kernel, player, item, "pdr");
}

