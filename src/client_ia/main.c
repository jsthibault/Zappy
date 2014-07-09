/*
** main.c for client_ia in /home/loic/dev/epitech/c/Zappy/src/client_ia
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 09 17:37:51 2014 lefloc_l
** Last update mer. juil. 09 17:37:57 2014 lefloc_l
*/

#include <stdio.h>
#include <stdlib.h>
#include "client_option.h"

t_bool		is_num(char *str)
{
  size_t	j;

  if (!str)
    return (FALSE);
  for (j = 0; str[j]; ++j)
  {
    if (str[j] < '0' || str[j] > '9')
    {
      fprintf(stderr, "%s is not a number\n", str);
      return (FALSE);
    }
  }
  return (TRUE);
}

void	print_man()
{
  fprintf(stderr, "Usage : \n-n : nom d'equipe\n");
  fprintf(stderr, "-p port du serveur\n-h nom de la machine\n");
}

int		main(int ac, char **av)
{
  t_option	option;

  if (!parse_option(ac, av, &option))
    {
      print_man();
      return (EXIT_FAILURE);
    }
  init_client(&option);
  return (EXIT_SUCCESS);
}
