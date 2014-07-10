/*
** enw.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:52:22 2014 lefloc_l
** Last update jeu. juil. 10 22:52:28 2014 lefloc_l
*/

#include "client_action.h"

t_bool	enw(int fd, int egg, int player_id, t_pos pos)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "enw %d %d %d %d\n", egg, player_id, pos.x, pos.y);
  return (send_message(fd, res));
}
