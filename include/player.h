/*
** player.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:20:41 2014 lefloc_l
** Last update lun. juil. 07 14:58:11 2014 lefloc_l
*/

#ifndef PLAYER_H_
# define PLAYER_H_

# include "map.h"
# include "team.h"

# define DEFAULT_PV	10

void			add_player_to_team(t_kernel *, char *, t_player *);
void			delete_player(void *);
void			delete_player_by_id(t_kernel *, int);
void			remove_player(t_player *);
t_player		*init_player_with_teamname(t_kernel *, char *,
    t_client *);
int			get_max_id(t_kernel *);
t_player		*get_player_by_id(int id, t_list *players);
t_pos			get_dir(t_orientation);

#endif /* !PLAYER_H_ */
