/*
** seg.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:48:34 2014 lefloc_l
** Last update jeu. juil. 10 23:05:55 2014 lefloc_l
*/

#include <string.h>
#include "client_action.h"

t_bool	seg(int fd, char *winner)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "seg %s", winner);
  if (winner[strlen(winner)] != '\n')
    strcat(res, "\n");
  return (send_message(fd, res));
}
