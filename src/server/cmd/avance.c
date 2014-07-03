/*
** avance.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:35:52 2014 lefloc_l
** Last update jeu. juil. 03 17:06:24 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "logger.h"

int	cmd_avance(char **av, t_client *client, t_kernel *kernel)
{
  t_pos	pos;

  (void)av;
  logger_debug("%d avance !", client->player->id);
  pos = client->player->pos;
  if (client->player->orientation == NORTH)
    pos.y--;
  else if (client->player->orientation == SOUTH)
    pos.y++;
  else if (client->player->orientation == EAST)
    pos.x++;
  else
    pos.x--;
  get_right_position(kernel, &pos.y, &pos.x);
  move_player_on_map(kernel,
      client->player,
      pos.y,
      pos.x);
  return (0);
}
