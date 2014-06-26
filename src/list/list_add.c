/*
** list_add.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 15:57:09 2014 lefloc_l
** Last update Thu Jun 26 16:57:54 2014 arnaud drain
*/

#include "list.h"
#include "utils.h"

void		list_push_front(t_list **list, void *data)
{
  t_node	*node;

  if (!*list)
    *list = list_create();
  node = list_create_node(data);
  node->next = (*list)->head;
  if ((*list)->head)
    (*list)->head->prev = node;
  (*list)->head = node;
  if ((*list)->size == 0)
    (*list)->tail = node;
  (*list)->size++;
}

void		list_push_back(t_list **list, void *data)
{
  t_node	*node;

  if (!*list)
    *list = list_create();
  node = list_create_node(data);
  node->prev = (*list)->tail;
  if ((*list)->tail)
    (*list)->tail->next = node;
  (*list)->tail = node;
  if ((*list)->size == 0)
    (*list)->head = node;
  (*list)->size++;
}
