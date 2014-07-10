/*
** smg.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:48:52 2014 lefloc_l
** Last update jeu. juil. 10 23:06:31 2014 lefloc_l
*/

#include <string.h>
#include "client_action.h"
#include "server.h"

t_bool	smg(int fd, char *msg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "smg %s", msg);
  if (msg[strlen(msg)] != '\n')
    strcat(res, "\n");
  return (send_message(fd, res));
}

