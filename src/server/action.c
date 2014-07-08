/*
** action.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 03 16:26:34 2014 lefloc_l
** Last update Tue Jul  8 17:05:58 2014 arnaud drain
*/

#include <stdlib.h>
#include "server.h"
#include "utils.h"
#include "enum.h"

int		add_action(t_kernel *kernel, int time, t_client *client, char **av)
{
  t_actions	*actions;

  if (!(actions = malloc(sizeof(*(kernel->actions)))))
    return (-1);
  actions->time_left = time;
  actions->client = client;
  actions->av = av;
  list_push_front(&(kernel->actions), actions);
  return (0);
}

