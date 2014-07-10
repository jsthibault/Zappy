/*
** team_user.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:19:53 2014 lefloc_l
** Last update jeu. juil. 10 16:14:43 2014 lefloc_l
*/

#include "kernel.h"
#include "logger.h"

t_bool		player_in_team(t_team *team, t_player *player)
{
  t_node	*node;
  t_player	*p;

  if (!(team->players))
    return (FALSE);
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

t_bool		add_player_to_team(t_kernel *kernel, char *teamname,
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
      if (FALSE == list_push_back(&(team->players), player))
        return (FALSE);
      player->team = team;
      --(team->place_left);
    }
    else
      logger_error("{PLAYER} already joined team \"%s\"", teamname);
  }
  return (TRUE);
}
