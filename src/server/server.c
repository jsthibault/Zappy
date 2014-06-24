/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update mar. juin 24 14:57:59 2014 lefloc_l
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
#include "buffer.h"

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

static int	cmd_client(t_client *client, t_client **clients, t_buffer *buff)
{
  char		*buffer;

  buffer = read_on(client->fd, buff);
  if (!buffer)
    return (FALSE);
  printf("[\033[32;1mNb client : %d\033[0m] msg : [%s]\n", client->fd, buffer);
  return (launch_cmd(buffer, client));
}

static int	server(fd_set *fd_in, int sfd, t_client **clients,
		       t_buffer *buff)
{
  int		max;
  t_client	*tmp;
  int		ret;

  max = init_select(fd_in, sfd, *clients);
  select(max + 1, fd_in, NULL, NULL, NULL);
  if (FD_ISSET(sfd, fd_in) && add_client(sfd, clients))
    return (1);
  tmp = *clients;
  while (tmp)
    {
      if (FD_ISSET(tmp->fd, fd_in))
      {
        ret = cmd_client(tmp, clients, buff);
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
  t_buffer	tmp;

  tmp.next = NULL;
  if ((sfd = init(kernel->options.port)) == -1)
    return (-1);
  clients = NULL;
  printf("[\033[32;1mOK\033[0m] Serveur started\n");
  while (42)
    {
      if (server(&fd_in, sfd, &clients, &tmp))
	{
	  close(sfd);
	  return (1);
	}
    }
  return (0);
}
