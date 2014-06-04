/*
** parse_options.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 13:59:34 2014 lefloc_l
** Last update sam. mai 17 17:20:25 2014 lefloc_l
*/

#include <string.h>
#include "options.h"

static const t_tabfunctions	tabfunctions[] = {
  { "-p", &option_p },
  { "-x", &option_x },
  { "-y", &option_y },
  { "-n", &option_n },
  { "-c", &option_c },
  { "-t", &option_t },
  { NULL, NULL },
};

static t_bool	check_options(t_options *options)
{
  if (options->nb_team_names == 0)
  {
    print_error("Please create teams !");
    return (FALSE);
  }
  if (options->nb_team_names > TEAM_MAX)
  {
    print_error("Too much teams !");
  }
  return (TRUE);
}

t_bool		parse_options(const int ac, const char *av[], t_options *options)
{
  int		i;
  size_t	j;
  t_bool	check;

  for (i = 1; i < ac; ++i)
  {
    check = FALSE;
    for (j = 0; tabfunctions[j].option && !check; ++j)
    {
      if (!strcmp(tabfunctions[j].option, av[i]))
      {
        if (!tabfunctions[j].p(av, ac, &i, options))
          return (FALSE);
        check = TRUE;
      }
    }
    if (!check)
      return (FALSE);
  }
  return (check_options(options));
}

void		dump_options(t_options *options)
{
  size_t	i;

  printf("===== OPTIONS DUMP =====\n");
  printf("Port:\t%ld\nWidth:\t%ld\nHeight:\t%ld\nMax clients:\t%ld\nDelai:\t%ld\nTeams (%ld):\n",
      options->port, options->width, options->height,
      options->max_clients, options->delai, options->nb_team_names);
  for (i = 0; i < options->nb_team_names; ++i)
    printf("\t%s\n", options->team_names[i]);
  printf("===== END OPTIONS ======\n");
}

