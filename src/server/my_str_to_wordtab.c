/*
** my_str_to_wordtab.c for truc in /home/drain_a/rendu/PSU_2013_myftp
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Fri Apr 11 23:30:56 2014 arnaud drain
** Last update Thu Jun 26 01:31:38 2014 arnaud drain
*/

#include <stdlib.h>

static int	nb_word(char *str)
{
  int		nb;

  nb = 0;
  while (*str && *str != '\r' && *str != '\n')
    {
      while (*str && *str != '\r' && *str != '\n' && *str != ' ' && *str != '\t')
	++str;
      while (*str == ' ' || *str == '\t')
	++str;
      ++nb;
    }
  return (nb);
}

static int	nb_char(char *str)
{
  int		nb;

  nb = 0;
  while (str[nb] && *str != '\r' && str[nb] != '\n' && str[nb] != ' ' && str[nb] != '\t')
    ++nb;
  return (nb);
}

static char	*fill_string(char *str, char *target)
{
  int		i;

  i = 0;
  while (*str && *str != '\r' && *str != '\n' && *str != ' ' && *str != '\t')
    {
      target[i] = *str;
      ++i;
      ++str;
    }
  target[i] = 0;
  return (str);
}

char	**my_str_to_wordtab(char *str)
{
  char	**ret;
  int	pos;

  pos = 0;
  while (*str == ' ' || *str == '\t')
    ++str;
  if (!(ret = malloc(sizeof(*ret) * (nb_word(str) + 1))))
    return (NULL);
  while (*str && *str != '\r' && *str != '\n')
    {
      if (!(ret[pos] = malloc(sizeof(**ret) * (nb_char(str) + 1))))
	return (NULL);
      str = fill_string(str, ret[pos]);
      while (*str == ' ' || *str == '\t')
	++str;
      ++pos;
    }
  ret[pos] = NULL;
  return (ret);
}

void	freetab(char **tab)
{
  char	**tmp;

  tmp = tab;
  while (tmp && *tmp)
    {
      free(*tmp);
      ++tmp;
    }
  if (tab)
    free(tab);
}
