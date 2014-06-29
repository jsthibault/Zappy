/*
** concat_node.c for concat_node.c in /home/js/bufferisationNaxNax
**
** Made by thibau_j
** Login <thibau_j@epitech.net>
**
** Started on Sun May 25 20:13:49 2014 thibau_j
** Last update Sun Jun 29 17:26:56 2014 thibau_j
*/

#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include "buffer.h"
#include "utils.h"

static int	size_full_node(t_buffer *ptr)
{
  t_buffer	*tmp;
  int		nb;

  nb = 0;
  tmp = ptr;
  while (tmp != NULL)
    {
      if (tmp->full == 1)
        ++nb;
      tmp = tmp->next;
    }
  return (nb);
}

char		*concat_buff_node(t_buffer *ptr)
{
  int		nb;
  char		*str;
  t_buffer	*tmp;

  nb = size_full_node(ptr);
  if (!nb)
    return (NULL);
  str = malloc(sizeof(char) * (nb * (SIZE + 1)));
  if (str == NULL)
    {
      fprintf(stderr, "Malloc : failed system call malloc.\n");
      return (NULL);
    }
  memset(str, 0, nb * (SIZE + 1));
  tmp = ptr;
  while (tmp != NULL)
  {
    if (tmp->full == 1)
      strcat(str, tmp->buff);
    tmp = tmp->next;
  }
  return (str);
}
