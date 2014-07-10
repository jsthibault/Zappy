/*
** pie.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:51:29 2014 lefloc_l
** Last update jeu. juil. 10 22:51:40 2014 lefloc_l
*/

#include "client_action.h"

t_bool	pie(int fd, t_pos pos, int result)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pie %d %d %d\n", pos.x, pos.y, result);
  return (send_message(fd, res));
}
