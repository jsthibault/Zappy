/*
** expulse.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:39:34 2014 lefloc_l
** Last update Tue Jul  8 00:46:58 2014 arnaud drain
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "list.h"
#include "logger.h"

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
  sprintf(buffer, "deplacement: %d\n", cl->player->orientation);
  send_expulse_to_graphic(kernel, cl->player->id);
  while (node)
  {
    player = (t_player *)node->data;
    if (player->id != cl->player->id)
    {
      player->pos = new_pos;
      write_socket(player->client->fd, buffer);
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
