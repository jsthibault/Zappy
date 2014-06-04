/*
** list_get.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 16:31:08 2014 lefloc_l
** Last update sam. mai 17 18:05:53 2014 lefloc_l
*/

#include "list.h"
#include "utils.h"

void	*list_get_front(t_list *list)
{
  if (list->head)
    return (list->head->data);
  return (NULL);
}

void	*list_get_back(t_list *list)
{
  if (list->tail)
    return (list->tail->data);
  return (NULL);
}

void		*list_get_at(t_list *list, size_t pos)
{
  t_node	*node;

  if (pos > list->size)
    return (NULL);
  node = list->head;
  while (pos > 0)
  {
    node = node->next;
    pos--;
  }
  return (node->data);
}

void		*list_get_func(t_list *list, ptrbv func)
{
  t_node	*node;

  node = list->head;
  while (node && (*func)(node->data) == FALSE)
  {
    node = node->next;
  }
  if (node)
    return (node->data);
  return (NULL);
}

void		*list_get_func_arg(t_list *list, ptrbvv func, void *arg)
{
  t_node	*node;

  node = list->head;
  while (node && (*func)(node->data, arg) == FALSE)
    node = node->next;
  if (node)
    return (node->data);
  return (NULL);
}
