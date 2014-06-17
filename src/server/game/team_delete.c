/*
** team_delete.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:56:38 2014 lefloc_l
** Last update Tue Jun 17 16:19:34 2014 arnaud drain
*/

#include <string.h>
#include "kernel.h"
#include "logger.h"

static void		delete_by_name(__attribute__((__unused__))t_list *list,
    t_node *node, void *arg)
{
  t_team	*team;

  team = (t_team *)node->data;
  if (!team)
    return ;
  if (!strcmp(team->name, (char *)arg))
  {
    delete_team(node->data);
  }
}

void		delete_team_by_name(t_kernel *kernel, char *name)
{
  list_recur_action(kernel->game.teams, delete_by_name, name);
}

/*
** delete a team content (players list)
*/

void		delete_team(void *data)
{
  t_team	*team;

  team = (t_team *)data;
  if (!team)
    return ;
  if (team->players)
    list_delete(team->players);
  logger_message("{TEAM} Delete %s", team->name);
}

