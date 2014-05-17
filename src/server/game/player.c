/*
** player.c for game in /home/loic/dev/epitech/c/Zappy/src/server/game
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 18:36:43 2014 lefloc_l
** Last update sam. mai 17 18:47:11 2014 lefloc_l
*/

#include "kernel.h"
#include "logger.h"

extern t_kernel	*g_kernel;

static void	delete_by_id(__attribute__((__unused__))t_list *list, t_node *node, void *arg)
{
  t_player	*player;

  player = (t_player *)node->data;
  if (!player)
    return ;
  if (player->id == *(int *)arg)
  {
    delete_player(node->data);
  }
}

void		delete_player_by_id(int id)
{
  list_recur_action(g_kernel->game->players, delete_by_id, &id);
}

void		delete_player(void *data)
{
  t_player	*player;

  player = (t_player *)data;
  if (!player)
    return ;
  logger_message("{PLAYER} %d delete", player->id);
}

