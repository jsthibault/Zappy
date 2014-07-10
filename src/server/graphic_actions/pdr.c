/*
** pdr.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:50:45 2014 lefloc_l
** Last update jeu. juil. 10 22:50:56 2014 lefloc_l
*/

#include "client_action.h"

t_bool	pdr(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pdr %d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}

