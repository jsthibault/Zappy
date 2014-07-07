/*
** incantation.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:40:13 2014 lefloc_l
** Last update Mon Jul  7 17:49:46 2014 arnaud drain
*/

#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"

static const t_incantation g_incantations[] =
  {
    {1, {1, 0, 0, 0, 0, 0}},
    {2, {1, 1, 1, 0, 0, 0}},
    {2, {2, 0, 1, 0, 2, 0}},
    {4, {1, 1, 2, 0, 1, 0}},
    {4, {1, 2, 1, 3, 0, 0}},
    {6, {1, 2, 3, 0, 1, 0}},
    {6, {2, 2, 2, 2, 2, 1}}
  };

int		cmd_incantation(char **av, t_client *cl, t_kernel *kernel)
{
  t_case	*c;
  int		i;

  (void)av;
  if (cl->player->level > MAX_LVL)
    return (ko(cl->fd));
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  if (g_incantations[cl->player->level - 1].nb_player != (int)list_size(c->players))
    return (ko(cl->fd));
  i = 0;
  while (i < 6)
    {
      if (g_incantations[cl->player->level - 1].res[i] != c->inventory.items[i + 1])
	return (ko(cl->fd));
      ++i;
    }
  if (write_socket(cl->fd, "elevation en cours\n") <= 0)
    return (1);
  return (0);
}
