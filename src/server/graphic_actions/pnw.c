/*
** pnw.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:51:18 2014 lefloc_l
** Last update jeu. juil. 10 23:12:52 2014 lefloc_l
*/

#include "client_action.h"

t_bool	pnw(int fd, t_player *player)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pnw %d %d %d %d %d %s\n", player->id,
      player->pos.x, player->pos.y,
      player->orientation, player->level, player->team->name);
  return (send_message(fd, res));
}
