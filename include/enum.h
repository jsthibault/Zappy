/*
** enum.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mer. mai 14 19:13:54 2014 lefloc_l
** Last update ven. mai 16 16:15:50 2014 lefloc_l
*/

#ifndef ENUM_H_
# define ENUM_H_

/*
** define -> number of items defines on enum e_item
*/

# define ITEM_TYPE	7

typedef enum	e_orientation
{
  NORTH = 0,
  EAST = 1,
  SOUTH = 2,
  WEST = 3
}		t_orientation;

/*
** enum -> define all different items
*/

typedef enum	e_item
{
  FOOD = 0,
  LINEMATE = 1,
  DERAUMETRE = 2,
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

/*
** inventory. contain items. Each case = 1 item. (FOOD = items[0])
** The int on the case = number of this item
*/

typedef struct	s_inventory
{
  int		items[ITEM_TYPE];
}		t_inventory;

#endif /* !ENUM_H_ */
