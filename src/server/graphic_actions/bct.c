/*
** bct.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:47:31 2014 lefloc_l
** Last update jeu. juil. 10 23:09:44 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "server.h"
#include "client_action.h"

int		print_bct(int fd, t_case *map_case, int x, int y)
{
  char		buf[BUFFER_SIZE];
  int		*items;

  items = map_case->inventory.items;
  sprintf(buf, "bct %d %d %d %d %d %d %d %d %d\n", x, y, items[0],
          items[1], items[2], items[3], items[4], items[5], items[6]);
  return (write_socket(fd, buf));
}

int	bct(char **av, t_client *cl, t_kernel *kernel)
{
  t_pos	pos;

  if (av_length(av) != 3)
    return (sbp(cl->fd));
  pos.x = atoi(av[1]);
  pos.y = atoi(av[2]);
  if (print_bct(cl->fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y) <= 0)
    return (1);
  return (0);
}
