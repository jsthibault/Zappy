/*
** incantation.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:40:13 2014 lefloc_l
** Last update Wed Jul  9 20:25:57 2014 arnaud drain
*/

#include <stdlib.h>
#include <string.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "logger.h"

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

static int	check_case_for_incantation(t_case *c, int lvl)
{
  t_node	*node;
  int		i;

  if (g_incantations[lvl - 1].nb_player != (int)list_size(c->players))
    return (0);
  node = c->players->head;
  while (node)
    {
      if (((t_player *)node->data)->level != lvl)
	return (0);
      node = node->next;
    }
  i = 0;
  while (i < 6)
    {
      if (g_incantations[lvl - 1].res[i] != c->inventory.items[i + 1])
	return (0);
      ++i;
    }
  return (1);
}

static int	finish_elevation(t_case *c, int lvl)
{
  t_node	*node;
  char		buffer[BUFFER_SIZE];
  int		ret;

  ret = 0;
  node = c->players->head;
  logger_debug("Fin d'incantation");
  sprintf(buffer, "niveau actuel : %d\n", lvl);
  while (node)
    {
      ((t_player *)node->data)->level = lvl;
      if (write_socket(((t_player *)node->data)->client->fd, buffer) <= 0)
	ret = 1;
      node = node->next;
    }
  return (ret);
}

int		incantation(char **av, t_client *cl, t_kernel *kernel)
{
  int		check;
  t_case	*c;

  (void)av;
  check = 0;
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  if (check_case_for_incantation(c, cl->player->level))
    check = 1;
  finish_elevation(c, cl->player->level + check);
  send_finish_elevation_to_graphic(kernel, c, cl->player, check);
  return (check_victory(kernel));
}

static int	launch_elevation(t_case *c)
{
  t_node	*node;
  int		ret;

  ret = 0;
  node = c->players->head;
  while (node)
    {
      if (write_socket(((t_player *)node->data)->client->fd,
		       "elevation en cours\n") <= 0)
	ret = 1;
      node = node->next;
    }
  return (ret);
}

int		cmd_incantation(char **av, t_client *cl, t_kernel *kernel)
{
  t_case	*c;
  char		**av2;

  (void)av;
  if (cl->player->level > MAX_LVL)
    return (ko(cl->fd));
  c = get_case(kernel, cl->player->pos.y, cl->player->pos.x);
  if (!check_case_for_incantation(c, cl->player->level))
    return (ko(cl->fd));
  send_elevation_to_graphic(kernel, c, cl->player);
  if (!(av2 = malloc(sizeof(*av2) * 2)))
    return (-1);
  if (!(av2[0] = strdup("elevation")))
    return (-1);
  av2[1] = NULL;
  if (add_action(kernel, 300, cl, av2))
    return (-1);
  return (launch_elevation(c));
}
