/*
** get_orientation.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  lun. juil. 07 14:41:35 2014 lefloc_l
** Last update Mon Jul  7 18:09:06 2014 arnaud drain
*/

#include "struct.h"
#include "enum.h"

t_pos		get_dir(t_orientation orientation)
{
  t_pos		dir;

  dir.x = 0;
  dir.y = 0;
  if (orientation == NORTH)
    dir.y--;
  else if (orientation == SOUTH)
    dir.y++;
  else if (orientation == EAST)
    dir.x++;
  else
    dir.x--;
  return (dir);
}

