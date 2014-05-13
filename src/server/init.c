/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update Tue May 13 19:41:13 2014 arnaud drain
*/

#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <netdb.h>
#include <sys/select.h>
#include <sys/time.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <string.h>
#include "server.h"

int			init(size_t port)
{
  int			sfd;
  struct sockaddr_in	sin;
  struct protoent	*pe;

  if (!(pe = getprotobyname("TCP")))
    return (return_error("getprotobyname", 1));
  if ((sfd = socket(AF_INET, SOCK_STREAM, pe->p_proto)) < 0)
    return (return_error("sfd", 1));
  sin.sin_family = AF_INET;
  sin.sin_port = htons(port);
  sin.sin_addr.s_addr = INADDR_ANY;
  if (bind(sfd, (struct sockaddr *)&sin, sizeof(sin)) == -1)
    {
      close(sfd);
      return (return_error("bind", 1));
    }
  if (listen(sfd, 42) == -1)
    {
      close(sfd);
      return (return_error("listen", 1));
    }
  return (sfd);
}
