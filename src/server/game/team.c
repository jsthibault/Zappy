/*
** team.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:21:09 2014 lefloc_l
** Last update Thu Jun 26 17:15:20 2014 arnaud drain
*/

#include <string.h>
#include "kernel.h"
#include "utils.h"
#include "logger.h"

void		add_team(t_kernel *kernel, char *teamname)
{
  t_team	*team;

  team = xmalloc(sizeof(t_team));
  strcpy(team->name, teamname);
  team->players = list_create();
  list_push_back(&(kernel->game.teams), team);
  logger_message("{TEAM} Create %s", teamname);
}

void		init_team(t_kernel *kernel)
{
  size_t	i;

  kernel->game.teams = list_create();
  for (i = 0; i < kernel->options.nb_team_names; i++)
  {
    if (!find_team(kernel, kernel->options.team_names[i]))
      add_team(kernel, kernel->options.team_names[i]);
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

t_team		*find_team(t_kernel *kernel, char *name)
{
  t_team	*team;

  team = list_get_func_arg(kernel->game.teams, name_equal, name);
  return (team);
}
