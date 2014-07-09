/*
** expulse.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:34 2014 lefloc_l
** Last update mer. juil. 09 17:39:36 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "list.h"
#include "logger.h"

static int	get_k(t_pos a, t_pos b)
{
  if (a.x == b.x && a.y == b.y)
    return (1);
  else if ((a.x + b.x == 0 && a.y == b.y)
      || (a.y + b.y == 0 && a.x == b.x))
    return (5);
  else if (a.x == b.x)
    return (7);
  return (3);
}

static void	send_to_client_expulse(t_kernel *kernel, t_player *player,
    t_client *cl, t_pos new_pos)
{
  char		buffer[BUFFER_SIZE];

  move_player_on_map(kernel, player, new_pos.y, new_pos.x);
  sprintf(buffer, "deplacement: %d\n",
      get_k(get_dir(cl->player->orientation), get_dir(player->orientation)));
  logger_debug("player: %d: %s", player->id, buffer);
  write_socket(player->client->fd, buffer);
  send_position_to_graphic(kernel, player);
}

static int	send_expulse(t_kernel *kernel, t_client *cl, t_list *players,
    t_pos new_pos)
{
  t_node	*node;
  t_player	*player;
  int		res;

  res = 0;
  if (!players)
  {
    logger_warning("send_expulse: list empty.");
    return 0;
  }
  node = players->head;
  send_expulse_to_graphic(kernel, cl->player->id);
  while (node)
  {
    player = (t_player *)node->data;
    if (player->id != cl->player->id)
    {
      send_to_client_expulse(kernel, player, cl, new_pos);
      res++;
    }
    node = node->next;
  }
  return (res);
}

int		cmd_expulse(char **av, t_client *cl, t_kernel *kernel)
{
  t_case	*c;
  t_pos		new_pos;

  (void)av;
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  new_pos = get_dir(cl->player->orientation);
  new_pos.x += cl->player->pos.x;
  new_pos.y += cl->player->pos.y;
  write_socket(cl->fd,
      (send_expulse(kernel, cl, c->players, new_pos) == 0) ? "ko\n" : "ok\n");
  return (0);
}
