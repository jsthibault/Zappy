/*
** plv.c for graphic_actions in /home/loic/dev/epitech/c/Zappy/src/server/graphic_actions
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 23:19:21 2014 lefloc_l
** Last update jeu. juil. 10 23:33:15 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "client_action.h"

int		plv(char **av, t_client *cl, t_kernel *kernel)
{
  int		nb_player;
  t_player	*tempory_player;
  char		buff[BUFFER_SIZE];

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  nb_player = atoi(av[1]);
  if (!(tempory_player = get_player_by_id(nb_player, kernel->game.players)))
    return (sbp(cl->fd));
  sprintf(buff, "plv %d %d\n", nb_player, tempory_player->level);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
