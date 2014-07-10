/*
** ebo.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:52:36 2014 lefloc_l
** Last update jeu. juil. 10 22:52:42 2014 lefloc_l
*/

#include "client_action.h"

t_bool	ebo(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "ebo %d\n", egg);
  return (send_message(fd, res));
}

