/*
** team.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:16:38 2014 lefloc_l
** Last update jeu. juil. 10 15:55:04 2014 lefloc_l
*/

#ifndef TEAM_H_
# define TEAM_H_

# include "struct.h"
# include "list.h"

t_bool	init_team(t_kernel *kernel);
void	delete_team(void *data);
t_team		*find_team(t_kernel *kernel, char *name);

#endif /* !TEAM_H_ */
