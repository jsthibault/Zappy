/*
** option.c for option in /home/canque_r/Zappy/src/client_ia
**
** Made by Rodrigue Canquery
** Login   <canque_r@Ubuntu-laptop>
**
** Started on  Sun Jul  6 09:24:58 2014 Rodrigue Canquery
** Last update mer. juil. 09 17:38:23 2014 lefloc_l
*/

#include <string.h>
#include <stdio.h>
#include "client_option.h"

t_tabfunctions	tabfunctions[] = {
  { "-p", &option_p },
  { "-h", &option_h },
  { "-n", &option_n },
  { NULL, NULL }
};

t_bool		parse_option(int ac, char *av[], t_option *options)
{
  int		i;
  size_t	j;
  t_bool	check;

  for (i = 1; i < ac; ++i)
    {
      strcpy(options->host, "localhost");
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
  if (options->port <= 1 || strlen(options->host) <= 0
      || strlen(options->team) <= 0)
    return (FALSE);
  return (TRUE);
}
