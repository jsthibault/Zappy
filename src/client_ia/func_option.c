/*
** func_option.c for func_option in /home/canque_r/Zappy/src/client_ia
** 
** Made by Rodrigue Canquery
** Login   <canque_r@Ubuntu-laptop>
** 
** Started on  Sun Jul  6 10:09:01 2014 Rodrigue Canquery
** Last update Sun Jul  6 13:29:27 2014 Rodrigue Canquery
*/

#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "client_option.h"

t_bool		convert_to_int(char *av[], int ac, int *i, size_t *n)
{
  if (*i + 1 > ac)
    return (FALSE);
  if (!is_num(av[*i + 1]))
    return (FALSE);
  *n = atoi(av[*i + 1]);
  ++(*i);
  if (*n == 0)
    {
      fprintf(stderr, "Can't be 0.\n");
      return (FALSE);
    }
  return (TRUE);
}

t_bool		option_n(char **av, int ac, int *i, t_option *options)
{
  ++(*i);
  if (*i >= ac || av[*i][0] == '-')
    return (FALSE);
  while (*i < ac && av[*i][0] != '-')
    {
      strncpy(options->team,
	      av[*i], 100);
      ++(*i);
    }
  --(*i);
  return (TRUE);
}

t_bool		option_h(char **av, int ac, int *i, t_option *options)
{
  ++(*i);
  if (*i >= ac || av[*i][0] == '-')
    return (FALSE);
  while (*i < ac && av[*i][0] != '-')
    {
      strncpy(options->host,
	     av[*i], 100);
      ++(*i);
    }
  --(*i);
  return (TRUE);
}

t_bool		option_p(char **av, int ac, int *i, t_option *options)
{
  return (convert_to_int(av, ac, i, &options->port));
}
