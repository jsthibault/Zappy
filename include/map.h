/*
** map.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:33:23 2014 lefloc_l
** Last update mar. mai 13 19:36:45 2014 lefloc_l
*/

#ifndef MAP_H_
# define MAP_H_

typedef struct	s_case
{
  int		nbFood;
  int		nbPierre[6];
  t_list	*players;
}		t_case;

typedef struct	s_map
{
  size_t	width;
  size_t	height;
  t_case	**map;
}		t_map;

#endif /* !MAP_H_ */
