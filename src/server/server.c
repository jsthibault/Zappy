/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update Thu Jul  3 17:39:21 2014 arnaud drain
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
#include "client_action.h"

static const t_functions g_functions[] =
    {
      {"GRAPHIC", graphic, AUTH, 0},
      {"avance", cmd_avance, CLIENT, 7},
      {"gauche", cmd_gauche, CLIENT, 7},
      {"droite", cmd_droite, CLIENT, 7},
      {"pose_objet", cmd_pose_objet, CLIENT, 7},
      {"prend_objet", cmd_prend_objet, CLIENT, 7},
      {NULL, NULL, AUTH, 0}
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

static int	game_auth(char **av, t_client *client, t_kernel *kernel)
{
  t_team	*team;
  char		buf[15];

  if (av[0] && !client->graphic && !client->player)
    {
      if (!(client->player = init_player_with_teamname(kernel, av[0])))
	{
	  freetab(av);
	  return (0);
	}
      team = find_team(kernel, av[0]);
      sprintf(buf, "%d\n%d %d\n", (int)(kernel->options.max_clients - list_size(team->players)),
	      (int)kernel->options.width, (int)kernel->options.height);
      write_socket(client->fd, buf);
    }
  freetab(av);
  return (0);
}

static int	launch_cmd(char *line, t_client *client, t_kernel *kernel)
{
  char		**av;
  int		i;
  int		ret;

  i = 0;
  if (!(av = my_str_to_wordtab(line)))
    return (-1);
  while (av[0] && g_functions[i].name)
    {
      if (!strcmp(av[0], g_functions[i].name))
	{
	  ret = 0;
	  if (g_functions[i].type == CLIENT && client->player)
	    {
	      if (add_action(kernel, g_functions[i].timeout, client, av))
		ret = -1;
	    }
	  else if ((g_functions[i].type == GRAPHIC && client->graphic) ||
		   (g_functions[i].type == AUTH && !(client->graphic) && !(client->player)))
	    {
	      ret = g_functions[i].function(av, client, kernel);
	      freetab(av);
	    }
	  return (ret);
	}
      ++i;
    }
  return (game_auth(av, client, kernel));
}

static int	cmd_client(t_client *client, t_client **clients,
			   t_kernel *kernel, t_buffer *buff_node)
{
  char		*buffer;

  buffer = read_on(client->fd, buff_node);
  if (buffer == NULL)
    {
      return (-1);
    }
  else if (buffer == (void *)2)
    {
      printf("[\033[31;1mOK\033[0m] Deconnection from %s\n", client->ip);
      close(client->fd);
      pop_client(client->fd, clients);
      return (1);
    }
  printf("[\033[32;1mClient %s\033[0m] msg : [%s]\n", client->ip, buffer);
  return (launch_cmd(buffer, client, kernel));
}

static void	pop_action(t_kernel *kernel, t_actions *action)
{
  t_actions	*actions_tmp;

  actions_tmp = kernel->actions;
  if (actions_tmp == action)
    kernel->actions = NULL;
  else
    {
      while (actions_tmp->next != action)
	actions_tmp = actions_tmp->next;
      actions_tmp->next = actions_tmp->next->next;
      actions_tmp = actions_tmp->next;
    }
  freetab(actions_tmp->av);
  free(actions_tmp);
}

static int	manage_actions(t_kernel *kernel)
{
  int		i;
  t_actions	*actions;
  t_actions	*actions_tmp;

  actions = kernel->actions;
  while (actions)
    {
      if (!(actions->time_left))
	{
	  i = 0;
	  while (actions->av[0] && g_functions[i].name && strcmp(actions->av[0], g_functions[i].name))
	    ++i;
	  if (actions->av[0] && g_functions[i].name)
	    g_functions[i].function(actions->av, actions->client, kernel);
	  actions_tmp = actions;
	  actions = actions->next;
	  pop_action(kernel, actions_tmp);
	}
      else
	{
	  --(actions->time_left);
	  actions = actions->next;
	}
    }
  (void)kernel;
  return (0);
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
      /*dump_map(kernel);*/
      if ((ret = manage_actions(kernel)))
	return (ret);
    }
  if (FD_ISSET(sfd, &fd_in) && add_client(sfd, clients))
    return (1);
  tmp = *clients;
  while (tmp)
    {
      if (FD_ISSET(tmp->fd, &fd_in))
      {
        if ((ret = cmd_client(tmp, clients, kernel, kernel->buff_node)))
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
  t_buffer		buff;

  buff.next = NULL;
  kernel->buff_node = &buff;
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
