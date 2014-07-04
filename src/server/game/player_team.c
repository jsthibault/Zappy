/*
** team_user.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:19:53 2014 lefloc_l
** Last update Fri Jul  4 17:05:42 2014 arnaud drain
*/

#include "kernel.h"
#include "logger.h"

t_bool		player_in_team(t_team *team, t_player *player)
{
  t_node	*node;
  t_player	*p;

  node = team->players->head;
  while (node)
  {
    p = (t_player *)node->data;
    if (p->id == player->id)
      return (TRUE);
    node = node->next;
  }
  return (FALSE);
}

void		add_player_to_team(t_kernel *kernel, char *teamname,
				   t_player *player)
{
  t_team	*team;

  if (!(team = find_team(kernel, teamname)))
    logger_error("{PLAYER} Can't join team \"%s\". Team \
        doesn't exists", teamname);
  else
  {
    if (FALSE == player_in_team(team, player))
    {
      list_push_back(&(team->players), player);
      player->team = team;
    }
    else
      logger_error("{PLAYER} already joined team \"%s\"", teamname);
  }
}
