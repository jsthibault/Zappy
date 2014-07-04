/*
** send_to_graphic.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. juil. 04 15:38:31 2014 lefloc_l
** Last update ven. juil. 04 15:43:05 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"

void	send_ppo_to_graphic(t_kernel *kernel, t_client *client)
{
  char	buffer[BUFFER_SIZE];

  sprintf(buffer, "ppo %d %d %d %d\n", client->player->id, client->player->pos.x,
      client->player->pos.y, client->player->orientation);
  write_all_graphic(kernel, buffer);
}


