/*
** write_socket.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:46:07 2014 lefloc_l
** Last update jeu. juil. 10 23:36:51 2014 lefloc_l
*/

#include <sys/types.h>
#include <sys/socket.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include "utils.h"
#include "kernel.h"
#include "map.h"

int	write_socket(int fd, char *str)
{
  return (send(fd, str, strlen(str), MSG_NOSIGNAL));
}

