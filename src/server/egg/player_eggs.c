/*
** eggs.c for eggs in /home/drain_a/rendu/Zappy
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Thu Jul 10 23:21:32 2014 arnaud drain
** Last update Fri Jul 11 01:44:39 2014 arnaud drain
*/

#include <stdlib.h>
#include <string.h>
#include "struct.h"
#include "server.h"
#include "client_action.h"

static t_egg	*find_egg_team(t_list *eggs, t_team *team)
{
  t_egg		*egg;
  t_node	*node;

  node = NULL;
  if (eggs)
    node = eggs->head;
  while (node)
    {
      egg = (t_egg *)node->data;
      if (!(egg->time_left) && !(strcmp(egg->team->name, team->name)))
	return (egg);
      node = node->next;
    }
  return (NULL);
}

static void	init_player_const_value(t_player *player)
{
  player->pv = DEFAULT_PV;
  player->level = 1;
  player->orientation = rand() % 4 + 1;
  player->food_time = 126;
  player->actions = NULL;
  player->from_egg = 1;
}

t_player	*init_player_with_egg(t_kernel *kernel, t_team *team,
				      t_client *cl)
{
  t_player	*player;
  t_egg		*egg;

  if (!(egg = find_egg_team(kernel->game.eggs, team)))
    return (NULL);
  if (!(player = malloc(sizeof(*player))))
    return (NULL);
  init_player_const_value(player);
  player->id = get_max_id(kernel) + 1;
  player->pos.x = egg->pos.x;
  player->pos.y = egg->pos.y;
  if (FALSE == add_player_to_team(kernel, team->name, player))
    return (NULL);
  if (FALSE == list_push_back(&(kernel->game.players), player))
    return (NULL);
  player->team = team;
  if (FALSE == add_player_on_map(kernel, player, player->pos.x, player->pos.y))
    return (NULL);
  player->client = cl;
  init_inventory(&(player->inventory));
  send_egg_connexion_to_graphic(kernel, player, egg->id);
  list_pop(&(kernel->game.eggs), egg);
  return (player);
}
