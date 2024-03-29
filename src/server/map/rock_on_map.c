/*
** pierre_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:53:04 2014 lefloc_l
** Last update Tue Jun 17 15:42:34 2014 arnaud drain
*/

#include <stdio.h>
#include "map.h"

t_bool		incr_rock_on_case(t_kernel *kernel, int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(kernel, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[type]++;
  return (TRUE);
}

t_bool		decr_rock_on_case(t_kernel *kernel, int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(kernel, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[type]--;
  return (TRUE);
}
