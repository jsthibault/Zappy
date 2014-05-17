/*
** team.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:21:09 2014 lefloc_l
** Last update sam. mai 17 18:56:13 2014 lefloc_l
*/

#include <string.h>
#include "kernel.h"
#include "utils.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void		add_team(char *teamname)
{
  t_team	*team;

  team = xmalloc(sizeof(t_team));
  strcpy(team->name, teamname);
  team->players = NULL;
  list_push_back(g_kernel->game->teams, team);
  logger_message("{TEAM} Create %s", teamname);
}

void		init_team()
{
  size_t	i;

  g_kernel->game->teams = list_create();
  for (i = 0; i < g_kernel->options.nb_team_names; i++)
  {
    if (!find_team(g_kernel->options.team_names[i]))
      add_team(g_kernel->options.team_names[i]);
    else
      logger_warning("{TEAM} %s already exists");
  }
}

static t_bool	name_equal(void *data, void *arg)
{
  t_team	*team;

  team = (t_team *)data;
  if (!strcmp(team->name, (char *)arg))
    return (TRUE);
  return (FALSE);
}

t_team		*find_team(char *name)
{
  t_team	*team;

  team = list_get_func_arg(g_kernel->game->teams, name_equal, name);
  return (team);
}
