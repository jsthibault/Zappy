/*
** ko.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:47:11 2014 lefloc_l
** Last update jeu. juil. 10 23:39:28 2014 lefloc_l
*/

#include "server.h"

int	ko(int fd)
{
  if (write_socket(fd, "ko\n") <= 0)
    return (1);
  return (0);
}

