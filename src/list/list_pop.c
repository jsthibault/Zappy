/*
** list_pop.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 16:01:42 2014 lefloc_l
** Last update jeu. juil. 03 17:30:33 2014 lefloc_l
*/

#include <stdlib.h>
#include "list.h"
#include "utils.h"

void		list_pop(t_list **list, void *data)
{
  t_node	*node;

  if (!(*list) || !data)
    return ;
  node = (*list)->head;
  while (node)
  {
    if (node->data == data)
    {
      list_pop_node((*list), node);
      break ;
    }
    node = node->next;
  }
}

void		list_pop_front(t_list **list)
{
  t_node	*node;

  if (!(*list) || !(*list)->head)
    return ;
  node = (*list)->head;
  (*list)->head = node->next;
  (*list)->size--;
  if ((*list)->head)
    (*list)->head->prev = NULL;
  else
    (*list)->tail = NULL;
  free(node);
  list_pop_verification(list);
}

void		list_pop_back(t_list **list)
{
  t_node	*node;

  if (!(*list) || !(*list)->tail)
    return;
  node = (*list)->tail;
  (*list)->tail = node->prev;
  (*list)->size--;
  if ((*list)->tail)
    (*list)->tail->next = NULL;
  else
    (*list)->head = NULL;
  free(node);
  list_pop_verification(list);
}

void		list_pop_func(t_list **list, ptrbv func)
{
  t_node	*node;

  if (!(*list))
    return;
  node = (*list)->head;
  while (node && (*func)(node->data) == FALSE)
  {
    node = node->next;
  }
  if (node)
    list_pop_node((*list), node);
}

void		list_pop_func_arg(t_list **list, ptrbvv func, void *arg)
{
  t_node	*node;

  if (!(*list))
    return;
  node = (*list)->head;
  while (node && (*func)(node->data, arg) == FALSE)
  {
    node = node->next;
  }
  if (node)
    list_pop_node((*list), node);
}
