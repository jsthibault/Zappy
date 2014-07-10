/*
** edi.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:50:16 2014 lefloc_l
** Last update jeu. juil. 10 22:50:26 2014 lefloc_l
*/

#include "client_action.h"

t_bool	edi(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "edi %d\n", egg);
  return (send_message(fd, res));
}
