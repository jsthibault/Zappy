/*
** food_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:52:18 2014 lefloc_l
** Last update Tue Jun 17 15:47:31 2014 arnaud drain
*/

#include <stdio.h>
#include "kernel.h"

t_bool		incr_food_on_case(t_kernel *kernel, int y, int x)
{
  t_case	*_case;

  _case = get_case(kernel, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]++;
  return (TRUE);
}

t_bool		decr_food_on_case(t_kernel *kernel, int y, int x)
{
  t_case	*_case;

  _case = get_case(kernel, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]--;
  return (TRUE);
}
