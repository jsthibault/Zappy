/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update Mon Jun 16 16:57:48 2014 arnaud drain
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
#include "kernel.h"
#include "server.h"

static const t_functions g_functions[] =
    {
      {"GRAPHIC", graphic},
      {NULL, NULL}
    };

static int	init_select(fd_set *fd_in, int sfd, t_client *clients)
{
  t_client	*tmp;
  int		max;

  tmp = clients;
  max = sfd;
  FD_ZERO(fd_in);
  FD_SET(sfd, fd_in);
  while (tmp)
    {
      FD_SET(tmp->fd, fd_in);
      if (tmp->fd > max)
	max = tmp->fd;
      tmp = tmp->next;
    }
  return (max);
}

static int	launch_cmd(char *line, t_client *client)
{
  char		**av;
  int		i;
  int		ret;

  i = 0;
  if (!(av = my_str_to_wordtab(line + 1)))
    return (-1);
  while (av[0] && g_functions[i].name)
    {
      if (!strcmp(av[0], g_functions[i].name))
	{
	  ret = g_functions[i].function(av, client);
	  freetab(av);
	  return (ret);
	}
      ++i;
    }
  freetab(av);
  return (0);
}

static int	cmd_client(t_client *client, t_client **clients)
{
  char		buffer[BUFFER_SIZE] = {0};

  if (read(client->fd, &buffer, sizeof(buffer)) <= 0)
    {
      printf("[\033[31;1mOK\033[0m] Deconnection from %s\n", client->ip);
      if (close(client->fd))
	return (-1);
      pop_client(client->fd, clients);
      return (1);
    }
  return (launch_cmd(buffer, client));
}

static int	server(fd_set *fd_in, int sfd, t_client **clients)
{
  int		max;
  int		ret;
  t_client	*tmp;

  max = init_select(fd_in, sfd, *clients);
  select(max + 1, fd_in, NULL, NULL, NULL);
  if (FD_ISSET(sfd, fd_in) && add_client(sfd, clients))
    return (1);
  tmp = *clients;
  while (tmp)
    {
      if (FD_ISSET(tmp->fd, fd_in))
	{
	  ret = cmd_client(tmp, clients);
	  if (ret)
	    return (ret);
	}
      tmp = tmp->next;
    }
  return (0);
}

int		launch_srv(t_kernel *kernel)
{
  int		sfd;
  t_client	*clients;
  fd_set	fd_in;

  if ((sfd = init(kernel->options.port)) == -1)
    return (-1);
  clients = NULL;
  printf("[\033[32;1mOK\033[0m] Serveur started\n");
  while (42)
    {
      if (server(&fd_in, sfd, &clients))
	{
	  close(sfd);
	  return (1);
	}
    }
  return (0);
}
