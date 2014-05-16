/*
** pierre_on_map.c for Zappy in /home/loic/dev/epitech/c/Zappy
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 18:53:04 2014 lefloc_l
** Last update mer. mai 14 19:16:27 2014 lefloc_l
*/

#include <stdio.h>
#include "map.h"

t_bool		incr_rock_on_case(t_map *map, int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(map, y, x);
  if (!_case)
    return (FALSE);
  _case->nb_rock[type]++;
  return (TRUE);
}

t_bool		decr_rock_on_case(t_map *map, int y, int x, int type)
{
  t_case	*_case;

  _case = get_case(map, y, x);
  if (!_case)
    return (FALSE);
  _case->nb_rock[type]--;
  return (TRUE);
}
