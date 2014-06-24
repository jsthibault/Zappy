/*
** map.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 19:33:23 2014 lefloc_l
** Last update mar. juin 24 15:58:36 2014 lefloc_l
*/

#ifndef MAP_H_
# define MAP_H_

# include <stdio.h>
# include "struct.h"
# include "kernel.h"
# include "utils.h"
# include "enum.h"
# include "list.h"
# include "player.h"

void	init_map(struct s_kernel *, int, int);
t_case	*get_case(struct s_kernel *, int, int);
t_bool	incr_food_on_case(struct s_kernel *, int, int);
t_bool	decr_food_on_case(struct s_kernel *, int, int);
t_bool	decr_rock_on_case(struct s_kernel *, int, int, int);
t_bool	incr_rock_on_case(struct s_kernel *, int, int, int);
void	delete_map(struct s_kernel *);
void	move_player_on_map(t_kernel *, t_player *, int, int);
void	remove_player_on_map(t_kernel *, t_player *);
void	add_player_on_map(t_kernel *, t_player *, int, int);

#endif /* !MAP_H_ */
