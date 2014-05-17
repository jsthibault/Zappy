/*
** food_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:52:18 2014 lefloc_l
** Last update sam. mai 17 14:33:55 2014 lefloc_l
*/

#include <stdio.h>
#include "map.h"

extern t_map		*g_map;

t_bool		incr_food_on_case(int y, int x)
{
  t_case	*_case;

  _case = get_case(y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]++;
  return (TRUE);
}

t_bool		decr_food_on_case(int y, int x)
{
  t_case	*_case;

  _case = get_case(y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]--;
  return (TRUE);
}
