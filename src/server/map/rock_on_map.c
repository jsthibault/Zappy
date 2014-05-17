/*
** pierre_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:53:04 2014 lefloc_l
** Last update sam. mai 17 19:33:00 2014 lefloc_l
*/

#include <stdio.h>
#include "map.h"

t_bool		incr_rock_on_case(int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[type]++;
  return (TRUE);
}

t_bool		decr_rock_on_case(int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[type]--;
  return (TRUE);
}
