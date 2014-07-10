/*
** sbp.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:49:20 2014 lefloc_l
** Last update jeu. juil. 10 23:03:09 2014 lefloc_l
*/

#include "client_action.h"

int	sbp(int fd)
{
  if (write_socket(fd, "sbp\n") <= 0)
    return (1);
  return (0);
}

