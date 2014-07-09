/*
** liste_loop.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 16:21:56 2014 lefloc_l
** Last update Wed Jul  9 02:57:59 2014 arnaud drain
*/

#include "list.h"

void		list_foreach(t_list *list, ptrvv func)
{
  t_node	*node;

  if (!list)
    return;
  node = list->head;
  while (node)
  {
    if (node->data)
      (*func)(node->data);
    node = node->next;
  }
}

void		*list_recur_action(t_list *list, ptrvnv func, void *arg)
{
  t_node	*node;

  if (!list)
    return (NULL);
  node = list->head;
  while (node)
  {
    (*func)(list, node, arg);
    node = node->next;
  }
  return (node);
}
