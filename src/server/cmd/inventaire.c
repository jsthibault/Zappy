/*
** inventaire.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:53 2014 lefloc_l
** Last update Tue Jul  8 11:00:51 2014 arnaud drain
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_inventaire(char **av, t_client *cl, t_kernel *kernel)
{
  int		*items;
  char		buffer[BUFFER_SIZE];

  (void)av;
  (void)kernel;
  items = cl->player->inventory.items;
  sprintf(buffer, "{nourriture %d, sibur %d, phiras %d, linemate %d,",
      items[FOOD], items[SIBUR], items[PHIRAS], items[LINEMATE]);
  sprintf(buffer, "%s deraumere %d, mendiane %d, thystame %d}\n", buffer,
      items[DERAUMERE], items[MENDIANE], items[THYSTAME]);
  write_socket(cl->fd, buffer);
  return (0);
}
