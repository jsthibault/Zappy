/*
** player.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:20:41 2014 lefloc_l
** Last update sam. mai 17 19:12:03 2014 lefloc_l
*/

#ifndef PLAYER_H_
# define PLAYER_H_

# include "map.h"
# include "team.h"

typedef struct	s_player
{
  int		id;
  t_pos		pos;
  t_team	*team;
}		t_player;

void	add_player_to_team(char *teamname, t_player *player);
void		delete_player(void *data);
void		delete_player_by_id(int id);

#endif /* !PLAYER_H_ */
