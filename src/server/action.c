/*
** action.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 03 16:26:34 2014 lefloc_l
** Last update Thu Jul  3 16:44:06 2014 arnaud drain
*/

#include <stdlib.h>
#include "server.h"
#include "utils.h"
#include "enum.h"

int		add_action(t_kernel *kernel, int time, t_client *client, char **av)
{
  t_actions	*actions;
  if (!(kernel->actions))
    {
      if (!(kernel->actions = malloc(sizeof(*(kernel->actions)))))
	return (-1);
      actions = kernel->actions;
    }
  else
    {
      actions = kernel->actions;
      while (actions->next)
	actions = actions->next;
      if (!(actions->next = malloc(sizeof(*(kernel->actions)))))
	return (-1);
      actions = actions->next;
    }
  actions->time_left = time;
  actions->client = client;
  actions->av = av;
  actions->next = NULL;
  return (0);
}

