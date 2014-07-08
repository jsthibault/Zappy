/*
** avance.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:35:52 2014 lefloc_l
<<<<<<< HEAD
** Last update mar. juil. 08 14:26:09 2014 lefloc_l
||||||| merged common ancestors
** Last update Sun Jul  6 14:15:45 2014 arnaud drain
=======
** Last update Tue Jul  8 12:36:18 2014 arnaud drain
>>>>>>> eda795d96624337ec1bf6263b968477236df0de3
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
  move_player_on_map(kernel,
      client->player,
      pos.y,
      pos.x);
  write_socket(client->fd, "ok\n");
  send_position_to_graphic(kernel, client->player);
  logger_debug("%d avance !", client->player->id);
  return (0);
}
