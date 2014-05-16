/*
** map.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:33:23 2014 lefloc_l
** Last update mer. mai 14 19:29:16 2014 lefloc_l
*/

#ifndef MAP_H_
# define MAP_H_

# include <stdio.h>
# include "utils.h"

// Temporaire. -> delete compilo error
typedef struct	s_list {

}		t_list;

typedef struct	s_case
{
  int		nb_food;
  int		nb_rock[6];
  t_list	*players;
}		t_case;

typedef struct	s_map
{
  size_t	width;
  size_t	height;
  t_case	**map;
}		t_map;

t_case	*get_case(t_map *, int, int);

t_bool	incr_food_on_case(t_map *, int, int);
t_bool	decr_food_on_case(t_map *, int, int);

t_bool	decr_rock_on_case(t_map *, int, int, int);
t_bool	incr_rock_on_case(t_map *, int, int, int);

#endif /* !MAP_H_ */
