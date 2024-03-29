/*
** egg.h for zappy in /home/drain_a/rendu/Zappy
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Thu Jul 10 23:25:10 2014 arnaud drain
** Last update Fri Jul 11 00:45:20 2014 arnaud drain
*/

#ifndef EGG_H_
# define EGG_H_

# include "struct.h"

int		add_egg(t_kernel *kernel, t_player *player);
void		print_all_eggs(t_kernel *kernel);
void		manage_eggs(t_kernel *kernel);
t_player	*init_player_with_egg(t_kernel *, t_team *, t_client *);

#endif /* !EGG_H_ */
