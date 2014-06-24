/*
** buffer.c for buffer in /home/js/bufferisationNaxNax
**
** Made by thibau_j
** Login <thibau_j@epitech.net>
**
** Started on Sun May 25 17:48:54 2014 thibau_j
** Last update mar. juin 24 13:47:38 2014 lefloc_l
*/

#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <unistd.h>
#include "buffer.h"

static void	init_buffer(t_buffer *ptr)
{
  t_buffer	*tmp;

  tmp = ptr;
  while (tmp != NULL)
    {
      tmp->full = 0;
      memset(tmp->buff, 0, SIZE + 1);
      tmp = tmp->next;
    }
}

static void	copy_on(char dest[SIZE + 1], char src[SIZE + 1])
{
  int	i;

  i = 0;
  while (src[i] != '\0')
    {
      dest[i] = src[i];
      ++i;
    }
}

static int	add_node_end(char buff[SIZE + 1], t_buffer **ptr)
{
  t_buffer	*tmp;
  t_buffer	*new;

  new = malloc(sizeof(t_buffer));
  if (new == NULL)
    {
      fprintf(stderr, "Failed on malloc\n");
      return (-1);
    }
  memset(new->buff, 0, sizeof(t_buffer));
  copy_on(new->buff, buff);
  new->next = NULL;
  new->full = 1;
  tmp = *ptr;
  while (tmp->next != NULL)
    {
      tmp = tmp->next;
    }
  tmp->next = new;
  return (0);
}

static int	add_node(char buff[SIZE + 1], t_buffer **ptr)
{
  t_buffer	*tmp;

  tmp = *ptr;
  while (tmp != NULL && tmp->full == 1)
    tmp = tmp->next;
  if (tmp == NULL)
    {
      if (add_node_end(buff, ptr) == -1)
        return (-1);
    }
  else
    {
      tmp->full = 1;
      copy_on(tmp->buff, buff);
    }
  return (0);
}

char	*read_on(int fd, t_buffer *ptr)
{
  int	nb;
  int	limit;
  char	buff[SIZE + 1];

  limit = 0;
  nb = 0;
  memset(buff, 0, SIZE + 1);
  init_buffer(ptr);
  while (limit == 0 && (nb = read(fd, buff, SIZE)) > 0)
    {
      buff[nb] = '\0';
      if (nb < SIZE || strchr(buff, '\n') != NULL)
        limit = 1;
      if (add_node(buff, &ptr) != 0)
        return (NULL);
    }
  if (nb == -1)
    {
      fprintf(stderr, "Failed on read.\n");
      return (NULL);
    }
  //check_node(ptr);
  return (concat_buff_node(ptr));
}
