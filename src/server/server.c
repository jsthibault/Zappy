/*
** main.c for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 13:25:28 2014 arnaud drain
** Last update ven. juil. 11 00:12:21 2014 lefloc_l
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
#include "logger.h"

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
  t_node	*node;
  t_actions	*action;

  if (manage_food(kernel))
    return (1);
  node = NULL;
  if (kernel->game.players)
    node = kernel->game.players->head;
  while (node)
    {
      action = list_get_front(((t_player *)node->data)->actions);
      if (action && !(action->time_left))
	{
	  if (launch_action(action, (t_player *)node->data, kernel))
	    return (-1);
	}
      else if (action)
	--(action->time_left);
      node = node->next;
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
  t_buffer		buff;

  buff.next = NULL;
  kernel->buff_node = &buff;
  if ((kernel->sfd = init(kernel->options.port)) == -1)
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
      if (server(kernel->sfd, kernel, &tv) < 0)
	return (1);
    }
  return (0);
}
