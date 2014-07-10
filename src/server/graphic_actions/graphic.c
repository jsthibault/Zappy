/*
** graphic.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:46:17 2014 lefloc_l
** Last update jeu. juil. 10 23:11:12 2014 lefloc_l
*/

#include "kernel.h"
#include "server.h"
#include "client_action.h"

int	graphic(char **av, t_client *cl, t_kernel *kernel)
{
  char	buf[BUFFER_SIZE];

  (void)av;
  if (cl->player)
    return (0);
  cl->graphic = TRUE;
  sprintf(buf, "msz %d %d\n", (int)kernel->options.width,
	  (int)kernel->options.height);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  if (print_tna(cl->fd, kernel) < 0)
    return (1);
  if (print_players(cl->fd, kernel) < 0)
    return (1);
  // liste des oeufs
  return (0);
}
