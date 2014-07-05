/*
** connexion.c for event in /home/loic/dev/epitech/c/Zappy/src/server/event
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. juil. 05 15:19:47 2014 lefloc_l
** Last update sam. juil. 05 15:20:25 2014 lefloc_l
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"

void		send_connexion_to_graphic(t_kernel *kernel, t_client *cl)
{
  char		buffer[BUFFER_SIZE];

  sprintf(buffer, "pnw #%d %d %d %d %d %s", cl->player->id, cl->player->pos.x,
      cl->player->pos.y, cl->player->orientation, cl->player->level,
      cl->player->team->name);
  write_all_graphic(kernel, buffer);
}

void		send_egg_connexion_to_graphic(t_kernel *kernel, t_client *cl,
    int egg_id)
{
  char		buffer[BUFFER_SIZE];

  sprintf(buffer, "ebo #%d\n", egg_id);
  write_all_graphic(kernel, buffer);
  send_connexion_to_graphic(kernel, cl);
}
