/*
** list.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 15:55:19 2014 lefloc_l
** Last update Wed Jul  9 02:45:48 2014 arnaud drain
*/

#include <stdlib.h>
#include "list.h"
#include "utils.h"

t_list		*list_create()
{
  t_list	*list;

  list = xmalloc(sizeof(t_list));
  list->size = 0;
  list->head = NULL;
  list->tail = NULL;
  return (list);
}

size_t		list_size(t_list *list)
{
  if (!list)
    return (0);
  return list->size;
}

t_bool		list_is_empty(t_list *list)
{
  if (!list)
    return (TRUE);
  if (!list->size)
    return (TRUE);
  return (FALSE);
}

void		list_delete(t_list *list)
{
  if (!list)
    return;
  list_foreach(list, &free);
  list_clear(list);
}

void		list_clear(t_list *list)
{
  while (list && list->size)
    list_pop_back(&list);
  free(list);
}
