/*
** list_perf.c for list in /home/loic/dev/epitech/c/Zappy/src/list
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. juil. 02 22:51:47 2014 lefloc_l
** Last update Fri Jul 11 00:20:44 2014 arnaud drain
*/

#include <stdlib.h>
#include "list.h"
#include "logger.h"

void	list_pop_verification(t_list **list)
{
  if (!list || !(*list))
    return;
  if (list_is_empty(*list))
  {
    free(*list);
    (*list) = NULL;
  }
}
