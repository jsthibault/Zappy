/*
** pex.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:52:04 2014 lefloc_l
** Last update jeu. juil. 10 22:52:15 2014 lefloc_l
*/

#include "client_action.h"

t_bool	pex(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pex %d\n", player_id);
  return (send_message(fd, res));
}


