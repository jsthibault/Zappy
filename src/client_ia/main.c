/*
** main.c for client_ia in /home/drain_a/rendu/Zappy/src/client_ia
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sat Jul  5 14:59:20 2014 arnaud drain
** Last update Sun Jul  6 13:30:23 2014 Rodrigue Canquery
*/

#include "client_option.h"
#include <stdio.h>
#include <stdlib.h>

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
  fprintf(stderr, "Usage : \n-n : nom d'equipe\n-p port du serveur\n-h nom de la machine\n");
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
