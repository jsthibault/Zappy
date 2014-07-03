/*
** avance.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:35:52 2014 lefloc_l
** Last update Wed Jul  2 16:31:03 2014 arnaud drain
*/

#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		add_action(t_kernel *kernel, int time, t_client *client, char *str)
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
  actions->test = str;
  actions->next = NULL;
  return (0);
}

int	cmd_avance(char **av, t_client *client, t_kernel *kernel)
{
  (void)av;
  if (client->graphic || !client->player)
    return (0);
  if (add_action(kernel, 7, client, "avance"))
    return (-1);
  return (0);
}
