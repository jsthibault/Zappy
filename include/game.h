/*
** game.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:13:20 2014 lefloc_l
** Last update jeu. juil. 10 22:32:20 2014 lefloc_l
*/

#ifndef GAME_H_
# define GAME_H_

# include "struct.h"
# include "list.h"
# include "map.h"
# include "team.h"
# include "player.h"

# define END_LVL		8
# define PLAYER_REQUIRED	6

t_bool	init_game(t_kernel *);
void	delete_game(t_kernel *);
t_bool	pre_fill_game(t_kernel *);
int	check_victory(t_kernel *);

#endif /* !GAME_H_ */
