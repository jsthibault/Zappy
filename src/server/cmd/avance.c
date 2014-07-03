/*
** avance.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:35:52 2014 lefloc_l
** Last update jeu. juil. 03 16:02:54 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_avance(char **av, t_client *client, t_kernel *kernel)
{
  if (client->graphic || !client->player)
    return (0);
  (void)av;
  (void)kernel;
  return (0);
}
