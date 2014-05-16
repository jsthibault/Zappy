/*
** utils.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:24:36 2014 lefloc_l
** Last update mer. mai 14 19:21:51 2014 lefloc_l
*/

#include <stdio.h>
#include <stdlib.h>
#include "utils.h"

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

t_bool		is_float(char *str)
{
  size_t	i;

  if (!str)
    return (FALSE);
  for (i = 0; str[i]; ++i)
  {
    if ((str[i] < '0' || str[i] > '9') && str[i] != '.')
    {
      fprintf(stderr, "%s is not a float number\n", str);
      return (FALSE);
    }
  }
  return (TRUE);
}

void	*xmalloc(size_t size)
{
  void	*ptr;

  if (!(ptr = malloc(size)))
  {
    fprintf(stderr, "Malloc failed.\n");
    exit(EXIT_FAILURE);
  }
  return (ptr);
}
