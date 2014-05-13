/*
** utils.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:24:36 2014 lefloc_l
** Last update mar. mai 13 15:28:40 2014 lefloc_l
*/

#include <stdio.h>

int		is_num(char *str)
{
  size_t	j;

  for (j = 0; str[j]; ++j)
  {
    if (str[j] < '0' || str[j] > '9')
    {
      fprintf(stderr, "%s is not a number\n", str);
      return (0);
    }
  }
  return (1);
}

int		is_float(char *str)
{
  size_t	i;

  for (i = 0; str[i]; ++i)
  {
    if ((str[i] < '0' || str[i] > '9') && str[i] != '.')
    {
      fprintf(stderr, "%s is not a float number\n", str);
      return (0);
    }
  }
  return (1);
}