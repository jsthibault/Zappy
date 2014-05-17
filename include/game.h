/*
** game.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:13:20 2014 lefloc_l
** Last update sam. mai 17 19:38:52 2014 lefloc_l
*/

#ifndef GAME_H_
# define GAME_H_

# include "list.h"
# include "map.h"
# include "team.h"
# include "player.h"

typedef struct	s_game
{
  t_list	*teams;
  t_list	*players;
  t_map		*map;
}		t_game;

void	init_game();
void	delete_game();

#endif /* !GAME_H_ */
