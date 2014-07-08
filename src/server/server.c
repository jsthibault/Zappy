/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
<<<<<<< HEAD
** Last update Tue Jul  8 17:29:26 2014 arnaud drain
||||||| merged common ancestors
** Last update mar. juil. 08 14:56:40 2014 lefloc_l
=======
** Last update mar. juil. 08 14:56:40 2014 lefloc_l
>>>>>>> eda795d96624337ec1bf6263b968477236df0de3
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
#include "logger.h"

static const t_functions g_functions[] =
    {
      {"GRAPHIC", graphic, AUTH, 0},
      {"msz", msz, GRAPHIC, 0},
      {"bct", bct, GRAPHIC, 0},
      {"mct", mct, GRAPHIC, 0},
      {"tna", tna, GRAPHIC, 0},
      {"ppo", ppo, GRAPHIC, 0},
      {"plv", plv, GRAPHIC, 0},
      {"pin", pin, GRAPHIC, 0},
      {"sgt", sgt, GRAPHIC, 0},
      {"sst", sst, GRAPHIC, 0},
      {"avance", cmd_avance, CLIENT, 7},
      {"gauche", cmd_gauche, CLIENT, 7},
      {"droite", cmd_droite, CLIENT, 7},
      {"pose_objet", cmd_pose_objet, CLIENT, 7},
      {"prend_objet", cmd_prend_objet, CLIENT, 7},
      {"inventaire", cmd_inventaire, CLIENT, 1},
      {"voir", cmd_voir, CLIENT, 7},
      {"prend", cmd_prend_objet, CLIENT, 7},
      {"pose", cmd_pose_objet, CLIENT, 7},
      {"expulse", cmd_expulse, CLIENT, 7},
      {"broadcast", cmd_broadcast_texte, CLIENT, 7},
      {"incantation", cmd_incantation, CLIENT, 0},
      {"fork", cmd_fork, CLIENT, 42},
      {"connect_nbr", cmd_connect_nbr, CLIENT, 0},
      {"elevation", incantation, SPECIAL, 0},
      {NULL, NULL, AUTH, 0}
    };

void		write_all_graphic(t_kernel *kernel, char *str)
{
  t_client	*client;

  client = kernel->clients;
  while (client)
    {
      if (client->graphic)
	write_socket(client->fd, str);
      client = client->next;
    }
}

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
      if (!(client->player = init_player_with_teamname(kernel, av[0], client)))
	{
	  freetab(av);
	  return (0);
	}
      team = find_team(kernel, av[0]);
      sprintf(buf, "%d\n%d %d\n",
	      (int)(kernel->options.max_clients - list_size(team->players)),
	      (int)kernel->options.width, (int)kernel->options.height);
      write_socket(client->fd, buf);
    }
  else if (client->graphic)
    write_socket(client->fd, "suc\n");
  freetab(av);
  return (0);
}

static char	*find_end(char *line)
{
  while (line && *line && *line != '\n')
    ++line;
  while (line && *line == '\n')
    ++line;
  return (line);
}

static int	launch_cmd(char *line, t_client *client, t_kernel *kernel)
{
  char		**av;
  int		i;
  int		ret;

  while (line && *line)
    {
      if (!(av = my_str_to_wordtab(line)))
	return (-1);
      i = 0;
      ret = 0;
      while (!ret && av[0] && g_functions[i].name)
	{
	  if (!strcmp(av[0], g_functions[i].name))
	    {
	      if (g_functions[i].type == CLIENT && client->player)
		{
		  if (add_action(kernel, g_functions[i].timeout, client, av))
		    ret = -1;
		}
	      else if ((g_functions[i].type == GRAPHIC && client->graphic) ||
		       (g_functions[i].type == AUTH && !(client->graphic) &&
			!(client->player)))
		{
		  ret = g_functions[i].function(av, client, kernel);
		  freetab(av);
		}
	      if (ret)
		return (ret);
	      ret = 1;
	    }
	  ++i;
	}
      if (!g_functions[i].name)
	if ((ret = game_auth(av, client, kernel)))
	  return (ret);
      line = find_end(line);
    }
  return (0);
}

static int	cmd_client(t_client *client, t_kernel *kernel,
			   t_buffer *buff_node)
{
  char		*buffer;

  buffer = read_on(client->fd, buff_node);
  if (buffer == NULL)
    return (-1);
  else if (buffer == (void *)2)
    {
      printf("[\033[31;1mOK\033[0m] Deconnection from %s\n", client->ip);
      close(client->fd);
      pop_client(client->fd, kernel);
      return (1);
    }
  printf("[\033[32;1mClient %s\033[0m] msg : [%s]\n", client->ip, buffer);
  return (launch_cmd(buffer, client, kernel));
}

static void	pop_action(t_kernel *kernel, t_node *node)
{
  freetab(((t_actions *)node->data)->av);
  free(node->data);
  list_pop_node(&(kernel->actions), node);
}

static int	manage_food(t_kernel *kernel)
{
  t_client	*client;

  client = kernel->clients;
  while (client)
    {
      if (client->player)
	{
	  --(client->player->food_time);
	  if (client->player->food_time == 0)
	    {
	      if (client->player->inventory.items[FOOD] == 0)
		{
		  write_socket(client->fd, "mort\n");
		  pop_client(client->fd, kernel);
		  return (1);
		}
	      --(client->player->inventory.items[FOOD]);
	      client->player->food_time = 126;
	    }
	}
      client = client->next;
    }
  return (0);
}

static int	manage_actions(t_kernel *kernel)
{
  int		i;
  t_node	*node;
  t_node	*node_tmp;
  t_actions	*action;

  if (manage_food(kernel))
    return (1);
  node = NULL;
  if (kernel->actions)
    node = kernel->actions->head;
  while (node)
    {
      action = (t_actions *)node->data;
      if (!(action->time_left))
	{
	  i = 0;
	  while (action->av[0] && g_functions[i].name &&
		 strcmp(action->av[0], g_functions[i].name))
	    ++i;
	  if (action->av[0] && g_functions[i].name)
	    g_functions[i].function(action->av, action->client, kernel);
	  node_tmp = node;
	  node = node->next;
	  pop_action(kernel, node_tmp);
	}
      else
	{
	  --(action->time_left);
	  node = node->next;
	}
    }
  return (0);
}

static int	server(int sfd, t_kernel *kernel, struct timeval *tv)
{
  fd_set	fd_in;
  int		max;
  t_client	*tmp;
  int		ret;

  max = init_select(&fd_in, sfd, kernel->clients);
  select(max + 1, &fd_in, NULL, NULL, tv);
  if (!tv->tv_sec && !tv->tv_usec)
    {
      if ((ret = manage_actions(kernel)))
	return (ret);
    }
  if (FD_ISSET(sfd, &fd_in) && add_client(sfd, kernel))
    return (1);
  tmp = kernel->clients;
  while (tmp)
    {
      if (FD_ISSET(tmp->fd, &fd_in))
      {
        if ((ret = cmd_client(tmp, kernel, kernel->buff_node)))
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
  t_buffer		buff;

  buff.next = NULL;
  kernel->buff_node = &buff;
  if ((sfd = init(kernel->options.port)) == -1)
    return (-1);
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
      if (server(sfd, kernel, &tv) < 0)
	{
	  close(sfd);
	  return (1);
	}
    }
  return (0);
}
