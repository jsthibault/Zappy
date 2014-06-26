/*
** node.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 16:09:14 2014 lefloc_l
** Last update Thu Jun 26 17:16:36 2014 arnaud drain
*/

#include <stdlib.h>
#include "list.h"
#include "utils.h"

t_node		*list_create_node(void *data)
{
  t_node	*node;

  node = xmalloc(sizeof(t_node));
  node->prev = NULL;
  node->next = NULL;
  node->data = data;
  return (node);
}

void		list_add_node(t_list **list, t_node *node, void *data)
{
  t_node	*tmp;

  if (!node)
    list_push_front(list, data);
  else if (!node->next)
    list_push_back(list, data);
  else
  {
    tmp = list_create_node(data);
    tmp->prev = node;
    tmp->next = node->next;
    tmp->next->prev = tmp;
    node->next = tmp;
    ((*list)->size++);
  }
}

void		list_pop_node(t_list *list, t_node *node)
{
  if (list->head == node)
    list_pop_front(list);
  else if (list->tail == node)
    list_pop_back(list);
  else
  {
    node->prev->next = node->next;
    node->next->prev = node->prev;
    free(node);
    list->size--;
  }
}
