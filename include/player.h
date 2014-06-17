/*
** player.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:20:41 2014 lefloc_l
** Last update Tue Jun 17 16:23:22 2014 arnaud drain
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

void	add_player_to_team(t_kernel *kernel, char *teamname, t_player *player);
void	delete_player(void *data);
void	delete_player_by_id(t_kernel *kernel, int id);

#endif /* !PLAYER_H_ */
