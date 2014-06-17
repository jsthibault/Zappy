/*
** game.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:13:20 2014 lefloc_l
** Last update Tue Jun 17 16:37:08 2014 arnaud drain
*/

#ifndef GAME_H_
# define GAME_H_

# include "struct.h"
# include "list.h"
# include "map.h"
# include "team.h"
# include "player.h"

void	init_game(t_kernel *);
void	delete_game(t_kernel *);
void	pre_fill_game(t_kernel *);

#endif /* !GAME_H_ */
