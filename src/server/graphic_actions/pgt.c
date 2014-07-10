/*
** pgt.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:50:35 2014 lefloc_l
** Last update jeu. juil. 10 22:50:42 2014 lefloc_l
*/

#include "client_action.h"

t_bool	pgt(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pgt %d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}
