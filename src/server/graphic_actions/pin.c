/*
** pin.c for graphic_actions in /home/loic/dev/epitech/c/Zappy/src/server/graphic_actions
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 23:19:46 2014 lefloc_l
** Last update jeu. juil. 10 23:23:29 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "client_action.h"

int		pin(char **av, t_client *cl, t_kernel *kernel)
{
  int           nb_player;
  t_player      *tmp_player;
  char          buff[BUFFER_SIZE];
  int		*items;

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  nb_player = atoi(av[1]);
  if (!(tmp_player = get_player_by_id(nb_player, kernel->game.players)))
    return (sbp(cl->fd));
  items = tmp_player->inventory.items;
  sprintf(buff, "pin %d %d %d %d %d %d %d %d %d %d\n", nb_player,
	  tmp_player->pos.x, tmp_player->pos.y, items[0], items[1],
	  items[2], items[3], items[4], items[5], items[6]);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
