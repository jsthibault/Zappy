/*
** fork.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:40:23 2014 lefloc_l
** Last update jeu. juil. 10 23:37:37 2014 lefloc_l
*/

#include <stdlib.h>
#include <string.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int	cmd_pond(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  (void)cl;
  (void)kernel;
  return (0);
}

int	cmd_fork(char **av, t_client *cl, t_kernel *kernel)
{
  char	buffer[BUFFER_SIZE];
  char	**av2;

  (void)av;
  sprintf(buffer, "pfk %d\n", cl->player->id);
  write_all_graphic(kernel, buffer);
  if (!(av2 = malloc(sizeof(*av2) * 2)))
    return (-1);
  if (!(av2[0] = strdup("pond")))
    return (-1);
  av2[1] = NULL;
  if (FALSE == add_action(42, cl->player, av2, 1))
    return (-1);
  return (0);
}
