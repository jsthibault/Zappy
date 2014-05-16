/*
** food_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:52:18 2014 lefloc_l
** Last update ven. mai 16 17:27:18 2014 lefloc_l
*/

#include <stdio.h>
#include "map.h"

t_bool		incr_food_on_case(t_map *map, int y, int x)
{
  t_case	*_case;

  _case = get_case(map, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]++;
  return (TRUE);
}

t_bool		decr_food_on_case(t_map *map, int y, int x)
{
  t_case	*_case;

  _case = get_case(map, y, x);
  if (!_case)
    return (FALSE);
  _case->inventory.items[0]--;
  return (TRUE);
}
