/*
** init_player.c for player in /home/loic/dev/epitech/c/Zappy/src/server/player
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. juin 24 15:29:59 2014 lefloc_l
** Last update Tue Jul  8 17:37:13 2014 arnaud drain
*/

#include <stdlib.h>
#include <string.h>
#include "kernel.h"
#include "client_action.h"
#include "logger.h"

int		get_max_id(t_kernel *kernel)
{
  int		max_id;
  t_player	*player;
  t_node	*node;

  max_id = 0;
  node = NULL;
  if (kernel->game.players)
    node = kernel->game.players->head;
  while (node)
    {
      player = (t_player *)node->data;
      if (player->id > max_id)
	max_id = player->id;
      node = node->next;
    }
  return (max_id);
}

void	init_inventory(t_inventory *inventory)
{
  int	i;
  int	*items;

  items = inventory->items;
  i = 0;
  while (i < ITEM_TYPE)
    {
      items[i] = 0;
      ++i;
    }
  items[FOOD] = 10;
}

t_player	*init_player_with_teamname(t_kernel *kernel, char *teamname,
    t_client *cl)
{
  t_team	*team;
  t_player	*player;
  t_pos		pos;

  if (!(team = find_team(kernel, teamname)))
    return (NULL);
  logger_debug("Adding a player to the team %s", teamname);
  if (!(player = malloc(sizeof(*player))))
    return (NULL);
  player->id = get_max_id(kernel) + 1;
  player->pv = DEFAULT_PV;
  pos.x = rand() % kernel->options.width;
  pos.y = rand() % kernel->options.height;
  player->pos.x = pos.x;
  player->pos.y = pos.y;
  list_push_back(&(team->players), player);
  list_push_back(&(kernel->game.players), player);
  player->team = team;
  add_player_on_map(kernel, player, pos.x, pos.y);
  player->level = 1;
  player->client = cl;
  player->orientation = rand() % 4 + 1;
  player->food_time = 126;
  init_inventory(&(player->inventory));
  send_connexion_to_graphic(kernel, player);
  return (player);
}

static t_bool	remove_player_on_team(void *c, void *p)
{
  t_player	*player;
  t_player	*current;

  current = (t_player *)c;
  player = (t_player *)p;
  if (player->id == current->id)
    return (TRUE);
  return (FALSE);
}

static t_bool	remove_action_from_player(void *c, void *p)
{
  t_player	*player;
  t_actions	*action;

  player = (t_player *)p;
  action = (t_actions *)c;
  if (player->id == action->client->player->id)
    {
      freetab(action->av);
      free(action);
      return (TRUE);
    }
  return (FALSE);
}

void	remove_player(t_kernel *kernel, t_player *player)
{
  send_deconnexion_to_graphic(kernel, player);
  list_pop_func_arg(&player->team->players, &remove_player_on_team, player);
  list_pop_func_arg(&kernel->actions, &remove_action_from_player, player);
  remove_player_on_map(kernel, player);
  list_pop_func_arg(&kernel->game.players, &remove_player_on_team, player);
  free(player);
}
