/*
** team.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 17:16:38 2014 lefloc_l
** Last update sam. mai 17 18:04:21 2014 lefloc_l
*/

#ifndef TEAM_H_
# define TEAM_H_

# include "list.h"

# define TEAM_NAME_SIZE		50
# define TEAM_MAX		100

typedef struct	s_team
{
  t_list	*players;
  char		name[TEAM_NAME_SIZE];
}		t_team;

void	init_team();
void	add_team();
void	delete_team();

t_team		*find_team(char *name);

#endif /* !TEAM_H_ */
