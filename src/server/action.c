/*
** action.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 03 16:26:34 2014 lefloc_l
** Last update Thu Jul 10 01:30:08 2014 arnaud drain
*/

#include <stdlib.h>
#include "server.h"
#include "utils.h"
#include "enum.h"

int		add_action(int time, t_player *player, char **av, int front)
{
  t_actions	*actions;

  if (!(actions = malloc(sizeof(*(actions)))))
    return (-1);
  actions->time_left = time;
  actions->av = av;
  if (front)
    list_push_front(&(player->actions), actions);
  else
    list_push_back(&(player->actions), actions);
  return (0);
}

