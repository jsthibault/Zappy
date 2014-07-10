/*
** avance.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:39:00 2014 lefloc_l
** Last update jeu. juil. 10 16:21:31 2014 lefloc_l
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
  if (FALSE == move_player_on_map(kernel,
      client->player,
      pos.y,
      pos.x))
    return (-1);
  write_socket(client->fd, "ok\n");
  send_position_to_graphic(kernel, client->player);
  logger_debug("%d avance !", client->player->id);
  return (0);
}
