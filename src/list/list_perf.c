/*
** list_perf.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 02 22:51:47 2014 lefloc_l
** Last update mer. juil. 02 22:53:15 2014 lefloc_l
*/

#include <stdlib.h>
#include "list.h"

void		list_pop_verification(t_list **list)
{
  if (!(*list)->head)
  {
    free((*list));
    (*list) = NULL;
  }
}
