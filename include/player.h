/*
** player.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:20:41 2014 lefloc_l
** Last update mar. juin 24 16:11:41 2014 lefloc_l
*/

#ifndef PLAYER_H_
# define PLAYER_H_

# include "map.h"
# include "team.h"

# define DEFAULT_PV	10

typedef struct		s_player
{
  int			id;
  t_pos			pos;
  t_team		*team;
  int			pv;
}			t_player;

void			add_player_to_team(t_kernel *, char *, t_player *);
void			delete_player(void *);
void			delete_player_by_id(t_kernel *, int);
t_player		*init_player(int, int, int);
void			remove_player(t_player *);

#endif /* !PLAYER_H_ */
