/*
** expulse.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:34 2014 lefloc_l
** Last update mar. juil. 08 14:04:39 2014 lefloc_l
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
  // same direction
  if (a.x == b.x && a.y == b.y)
    return (1);
  // inverse direction
  else if ((a.x + b.x == 0 && a.y == b.y)
      || (a.y + b.y == 0 && a.x == b.x))
    return (5);
  else if (a.x == b.x) // right
    return (7);
  // left
  return (3);
}

static void	send_expulse(t_kernel *kernel, t_client *cl, t_list *players,
    t_pos new_pos)
{
  t_node	*node;
  t_player	*player;
  char		buffer[BUFFER_SIZE];

  if (!players)
  {
    logger_warning("send_expulse: list empty.");
    return ;
  }
  node = players->head;
  send_expulse_to_graphic(kernel, cl->player->id);
  while (node)
  {
    player = (t_player *)node->data;
    if (player->id != cl->player->id)
    {
      player->pos.x = new_pos.x;
      player->pos.y = new_pos.y;
      sprintf(buffer, "deplacement: %d\n",
          get_k(get_dir(cl->player->orientation),
            get_dir(player->orientation)));
      logger_debug("player: %d: %s", player->id, buffer);
      write_socket(player->fd, buffer);
      send_position_to_graphic(kernel, player);
    }
    node = node->next;
  }
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
  send_expulse(kernel, cl, c->players, new_pos);
  return (0);
}
