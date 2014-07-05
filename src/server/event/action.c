/*
** send_to_graphic.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. juil. 04 15:38:31 2014 lefloc_l
** Last update Sat Jul  5 15:46:14 2014 arnaud drain
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"

void	send_position_to_graphic(t_kernel *kernel, t_player *player)
{
  char	buffer[BUFFER_SIZE];

  sprintf(buffer, "ppo #%d %d %d %d\n", player->id,
	  player->pos.x, player->pos.y,
	  player->orientation);
  write_all_graphic(kernel, buffer);
}

static void	prend_pose(t_kernel *kernel, t_player *player, int item, char *cmd)
{
  char		buffer[BUFFER_SIZE];
  int		*items;
  t_case	*map_case;

  map_case = get_case(kernel, player->pos.y, player->pos.x);
  items = player->inventory.items;
  sprintf(buffer, "%s #%d %d\n", cmd, player->id, item);
  sprintf(buffer, "%spin #%d %d %d %d %d %d %d %d %d %d\n",
      buffer, player->id, player->pos.x, player->pos.y, items[0],
      items[1], items[2], items[3], items[4], items[5], items[6]);
  items = map_case->inventory.items;
  sprintf(buffer, "%sbct %d %d %d %d %d %d %d %d %d\n", buffer,
      player->pos.x, player->pos.y, items[0], items[1], items[2],
      items[3], items[4], items[5], items[6]);
  write_all_graphic(kernel, buffer);
}

void		send_prend_to_graphic(t_kernel *kernel, t_player *player, int item)
{
  prend_pose(kernel, player, item, "pgt");
}

void		send_pose_to_graphic(t_kernel *kernel, t_player *player, int item)
{
  prend_pose(kernel, player, item, "pdr");
}
