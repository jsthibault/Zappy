/*
** print_players.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:46:44 2014 lefloc_l
** Last update jeu. juil. 10 23:12:17 2014 lefloc_l
*/

#include "kernel.h"
#include "client_action.h"

int		print_players(int fd, t_kernel *kernel)
{
  t_node	*node;

  if (!(kernel->game.players))
    return (0);
  node = kernel->game.players->head;
  while (node)
    {
      if (pnw(fd, ((t_player *)(node->data))) <= 0)
	return (-1);
      node = node->next;
    }
  return (0);
}
