/*
** team.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:21:09 2014 lefloc_l
** Last update jeu. juil. 10 16:27:28 2014 lefloc_l
*/

#include <stdlib.h>
#include <string.h>
#include "kernel.h"
#include "utils.h"
#include "logger.h"

static t_bool	add_team(t_kernel *kernel, char *teamname)
{
  t_team	*team;

  if (!(team = malloc(sizeof(t_team))))
    return (FALSE);
  strcpy(team->name, teamname);
  if (!(team->players = list_create()))
    return (FALSE);
  team->place_left = kernel->options.max_clients;
  if (FALSE == list_push_back(&(kernel->game.teams), team))
    return (FALSE);
  logger_message("{TEAM} Create %s", teamname);
  return (TRUE);
}

t_bool		init_team(t_kernel *kernel)
{
  size_t	i;

  if (!(kernel->game.teams = list_create()))
    return (FALSE);
  for (i = 0; i < kernel->options.nb_team_names; i++)
  {
    if (!find_team(kernel, kernel->options.team_names[i]))
    {
      if (FALSE == add_team(kernel, kernel->options.team_names[i]))
        return (FALSE);
    }
    else
      logger_warning("{TEAM} %s already exists");
  }
  return (TRUE);
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
