/*
** map.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:33:23 2014 lefloc_l
** Last update sam. mai 17 19:12:29 2014 lefloc_l
*/

#ifndef MAP_H_
# define MAP_H_

# include <stdio.h>
# include "utils.h"
# include "enum.h"
# include "list.h"

typedef struct	s_case
{
  t_inventory	inventory;
  t_list	*players;
}		t_case;

typedef struct	s_map
{
  int	width;
  int	height;
  t_case	**map;
}		t_map;

void	init_map(int, int);
t_case	*get_case(int, int);
t_bool	incr_food_on_case(int, int);
t_bool	decr_food_on_case(int, int);
t_bool	decr_rock_on_case(int, int, int);
t_bool	incr_rock_on_case(int, int, int);
void	delete_map();

#endif /* !MAP_H_ */
