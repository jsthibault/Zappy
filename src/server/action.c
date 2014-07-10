/*
** action.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 03 16:26:34 2014 lefloc_l
** Last update jeu. juil. 10 16:08:16 2014 lefloc_l
*/

#include <stdlib.h>
#include "server.h"
#include "utils.h"
#include "enum.h"

t_bool		add_action(int time, t_player *player, char **av, int front)
{
  t_actions	*actions;

  if (!(actions = malloc(sizeof(*(actions)))))
    return (FALSE);
  actions->time_left = time;
  actions->av = av;
  if (front)
    return list_push_front(&(player->actions), actions);
  return list_push_back(&(player->actions), actions);
}

