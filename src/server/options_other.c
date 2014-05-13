/*
** options_other.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:20:14 2014 lefloc_l
** Last update mar. mai 13 16:26:01 2014 lefloc_l
*/

#include <string.h>
#include <stdlib.h>
#include "options.h"

t_bool		option_n(char **av, int ac, int *i, t_options *options)
{
  *i += 1;
  if (*i >= ac)
    return (FALSE);
  if (av[*i][0] == '-')
    return (FALSE);
  while (1)
  {
    if (*i >= ac || av[*i][0] == '-')
      break;
    strncpy(options->team_names[options->nb_team_names], av[*i], 100);
    options->nb_team_names++;
    *i += 1;
  }
  return (TRUE);
}

t_bool	convert_to_int(char *av[], int ac, int *i, size_t *n)
{
  if (*i + 1 > ac)
    return (FALSE);
  if (!is_num(av[*i + 1]))
    return (FALSE);
  *n = atoi(av[*i + 1]);
  *i += 1;
  return (TRUE);
}
