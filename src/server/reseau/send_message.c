/*
** functions7.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:42:56 2014 lefloc_l
** Last update jeu. juil. 10 22:43:18 2014 lefloc_l
*/

#include "client_action.h"

t_bool	send_message(int fd, char *msg)
{
  write_socket(fd, msg);
  return (TRUE);
}


