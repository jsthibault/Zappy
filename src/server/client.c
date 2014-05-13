/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update Tue May 13 19:41:17 2014 arnaud drain
*/

#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include "server.h"

static int	fill_client(t_client *client, int cfd, char *address)
{
  client->fd = cfd;
  client->name = NULL;
  if (!(client->ip = strdup(address)))
    return (return_error("strdup", 1));
  client->next = NULL;
  return (0);
}

static int	push_client(int cfd, t_client **clients, char *address)
{
  t_client	*tmp;

  if (!(*clients))
    {
      if (!(*clients = malloc(sizeof(**clients))))
	return (return_error("malloc", 1));
      return (fill_client(*clients, cfd, address));
    }
  tmp = *clients;
  while (tmp->next)
    tmp = tmp->next;
  if (!(tmp->next = malloc(sizeof(**clients))))
    return (return_error("malloc", 1));
  return (fill_client(tmp->next, cfd, address));
}

int			add_client(int sfd, t_client **clients)
{
  struct sockaddr_in	sin_client;
  int			client_len;
  char			*address;
  int			cfd;
  char			msg[BUFFER_SIZE] = {0};

  client_len = sizeof(sin_client);
  if ((cfd = accept(sfd, (struct sockaddr *)&sin_client,
		    (socklen_t *)&client_len)) == -1)
    {
      perror("accept");
      return (0);
    }
  if (!(address = strdup(inet_ntoa(sin_client.sin_addr))))
    return (return_error("strdup", 1));
  printf("[\033[32;1mOK\033[0m] Connection from %s\n", address);
  snprintf(msg, sizeof(msg), "Hello, your ip is %s\n", address);
  write(cfd, msg, strlen(msg));
  if (push_client(cfd, clients, address))
    {
      close(cfd);
      return (-1);
    }
  return (0);
}

void		pop_client(int fd, t_client **clients)
{
  t_client	*tmp;
  t_client	*tmp_free;

  tmp = *clients;
  while (tmp->fd != fd && tmp->next->fd != fd)
    tmp = tmp->next;
  if (tmp->fd == fd)
    {
      tmp_free = tmp;
      *clients = tmp->next;
    }
  else
    {
      tmp_free = tmp->next;
      tmp->next = tmp->next->next;
    }
  if (tmp_free->name)
    free(tmp_free->name);
  free(tmp_free->ip);
  free(tmp_free);
}
