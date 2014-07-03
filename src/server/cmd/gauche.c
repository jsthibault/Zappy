/*
** gauche.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:18 2014 lefloc_l
** Last update jeu. juil. 03 16:39:14 2014 lefloc_l
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

int		cmd_gauche(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  (void)kernel;
  cl->player->orientation--;
  cl->player->orientation = cl->player->orientation < 0
    ? 4 : cl->player->orientation;
  return (0);
}
