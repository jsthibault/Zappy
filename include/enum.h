/*
** enum.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:13:54 2014 lefloc_l
** Last update jeu. juil. 03 17:49:16 2014 lefloc_l
*/

#ifndef ENUM_H_
# define ENUM_H_

/*
** define -> number of items defines on enum e_item
*/

# define ITEM_TYPE	7

typedef enum	e_orientation
{
  NORTH = 1,
  EAST = 2,
  SOUTH = 3,
  WEST = 4
}		t_orientation;

/*
** enum -> define all different items
*/

typedef enum	e_item
{
  FOOD = 0,
  LINEMATE = 1,
  DERAUMERE = 2,
  SIBUR = 3,
  MENDIANE = 4,
  PHIRAS = 5,
  THYSTAME = 6
}		t_item;

typedef struct	s_pos
{
  int		x;
  int		y;
}		t_pos;

#endif /* !ENUM_H_ */
