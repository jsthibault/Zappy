/*
** node.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 16:09:14 2014 lefloc_l
** Last update jeu. juil. 10 16:02:09 2014 lefloc_l
*/

#include <stdlib.h>
#include "list.h"
#include "utils.h"

t_node		*list_create_node(void *data)
{
  t_node	*node;

  if (!(node = malloc(sizeof(t_node))))
    return (NULL);
  node->prev = NULL;
  node->next = NULL;
  node->data = data;
  return (node);
}

t_bool		list_add_node(t_list **list, t_node *node, void *data)
{
  t_node	*tmp;

  if (!node)
    return list_push_front(list, data);
  else if (!node->next)
    return list_push_back(list, data);
  else
  {
    if (!(tmp = list_create_node(data)))
      return (FALSE);
    tmp->prev = node;
    tmp->next = node->next;
    tmp->next->prev = tmp;
    node->next = tmp;
    ((*list)->size++);
  }
  return (TRUE);
}

void		list_pop_node(t_list **list, t_node *node)
{
  if ((*list)->head == node)
    list_pop_front(list);
  else if ((*list)->tail == node)
    list_pop_back(list);
  else
  {
    node->prev->next = node->next;
    node->next->prev = node->prev;
    free(node);
    (*list)->size--;
  }
}
