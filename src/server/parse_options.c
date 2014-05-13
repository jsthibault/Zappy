/*
** parse_options.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 13:59:34 2014 lefloc_l
** Last update mar. mai 13 16:25:37 2014 lefloc_l
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
  return (TRUE);
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