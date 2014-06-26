/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update Thu Jun 26 02:18:00 2014 arnaud drain
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
#include "map.h"

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

static int	launch_cmd(char *line, t_client *client, t_kernel *kernel)
{
  t_team	*team;
  char		**av;
  int		i;
  int		ret;
  char		buf[15];

  i = 0;
  if (!(av = my_str_to_wordtab(line)))
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
  if (!client->graphic && !client->player)
    {
      if (!(client->player = init_player2(kernel, av[0])))
	{
	  freetab(av);
	  return (0);
	}
      team = find_team(kernel, av[0]);
      sprintf(buf, "%d\n%d %d\n", (int)(kernel->options.max_clients - list_size(team->players)),
	      (int)kernel->options.width, (int)kernel->options.height);
      write(client->fd, buf, strlen(buf));
    }
  freetab(av);
  return (0);
}

static int	cmd_client(t_client *client, t_client **clients, t_kernel *kernel)
{
   /* Js code, temporaly removed */
  /*char		*buffer;

  buffer = read_on(client->fd);
  if (!buffer)
    {
      printf("ici\n");
      return (-1);
      }*/
  char		buffer[BUFFER_SIZE] = {0};

  if (read(client->fd, &buffer, sizeof(buffer)) <= 0)
    {
      printf("[\033[31;1mOK\033[0m] Deconnection from %s\n", client->ip);
      close(client->fd);
      pop_client(client->fd, clients);
      return (1);
    }
  printf("[\033[32;1mClient %s\033[0m] msg : [%s]\n", client->ip, buffer);
  return (launch_cmd(buffer, client, kernel));
}

static int	server(int sfd, t_client **clients, t_kernel *kernel, struct timeval *tv)
{
  fd_set	fd_in;
  int		max;
  t_client	*tmp;
  int		ret;

  max = init_select(&fd_in, sfd, *clients);
  select(max + 1, &fd_in, NULL, NULL, tv);
  if (!tv->tv_sec && !tv->tv_usec)
    {
      dump_map(kernel);
    }
  if (FD_ISSET(sfd, &fd_in) && add_client(sfd, clients))
    return (1);
  tmp = *clients;
  while (tmp)
    {
      if (FD_ISSET(tmp->fd, &fd_in))
      {
        ret = cmd_client(tmp, clients, kernel);
        if (ret)
          return (ret);
      }
      tmp = tmp->next;
    }
  return (0);
}

int			launch_srv(t_kernel *kernel)
{
  struct timeval	tv;
  int			sfd;
  t_client		*clients;

  if ((sfd = init(kernel->options.port)) == -1)
    return (-1);
  clients = NULL;
  printf("[\033[32;1mOK\033[0m] Serveur started\n");
  tv.tv_sec = 0;
  tv.tv_usec = 0;
  while (42)
    {
      if (!tv.tv_sec && !tv.tv_usec)
	{
	  tv.tv_sec = 1 / kernel->options.delai;
	  tv.tv_usec = 1.0 / kernel->options.delai * 1000000;
	  if (tv.tv_sec)
	    tv.tv_usec -= 1000000 * tv.tv_sec;
	}
      if (server(sfd, &clients, kernel, &tv) < 0)
	{
	  close(sfd);
	  return (1);
	}
    }
  return (0);
}
