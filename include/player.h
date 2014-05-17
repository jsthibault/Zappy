/*
** player.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:20:41 2014 lefloc_l
** Last update sam. mai 17 18:42:17 2014 lefloc_l
*/

#ifndef PLAYER_H_
# define PLAYER_H_

# include "map.h"

typedef struct	s_player
{
  t_pos		pos;
  int		id;
}		t_player;

void	add_player_to_team(char *teamname, t_player *player);

void		delete_player(void *data);
void		delete_player_by_id(int id);

#endif /* !PLAYER_H_ */
