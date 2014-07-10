/*
** list_add.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 15:57:09 2014 lefloc_l
** Last update jeu. juil. 10 16:03:51 2014 lefloc_l
*/

#include "list.h"
#include "utils.h"
#include "enum.h"

t_bool		list_push_front(t_list **list, void *data)
{
  t_node	*node;

  if (!(*list))
  {
    if (!(*list = list_create()))
      return (FALSE);
  }
  if (!(node = list_create_node(data)))
    return (FALSE);
  node->next = (*list)->head;
  if ((*list)->head)
    (*list)->head->prev = node;
  (*list)->head = node;
  if ((*list)->size == 0)
    (*list)->tail = node;
  (*list)->size++;
  return (TRUE);
}

t_bool		list_push_back(t_list **list, void *data)
{
  t_node	*node;

  if (!(*list))
  {
    if (!(*list = list_create()))
      return (FALSE);
  }
  if (!(node = list_create_node(data)))
    return (FALSE);
  node->prev = (*list)->tail;
  if ((*list)->tail)
    (*list)->tail->next = node;
  (*list)->tail = node;
  if ((*list)->size == 0)
    (*list)->head = node;
  (*list)->size++;
  return (TRUE);
}
