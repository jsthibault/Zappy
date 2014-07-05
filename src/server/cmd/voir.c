/*
** voir.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:33 2014 lefloc_l
** Last update sam. juil. 05 15:43:40 2014 lefloc_l
*/

#include <string.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "logger.h"

char	g_item_names[ITEM_TYPE][20] = {
  "nourriture",
  "linemate",
  "deraumere",
  "sibur",
  "mendiane",
  "phiras",
  "thystame"
};

static void	dump_player_case(t_pos pos, t_client *cl, t_case *c,
    char buffer[BUFFER_SIZE])
{
  size_t	nb;

  nb = list_size(c->players);
  if (cl->player->pos.x == pos.x && cl->player->pos.y == pos.y)
    --nb;
  while (nb)
  {
    sprintf(buffer, "%s %s", buffer, "player");
    --nb;
  }
}

static	void	dump_case(t_kernel *kernel, t_client *cl, t_pos pos)
{
  t_case	*c;
  size_t	i;
  int		nb;
  char		buffer[BUFFER_SIZE];

  i = 0;
  logger_debug("%d %d\n", pos.x, pos.y);
  memset(buffer, 0, BUFFER_SIZE);
  c = get_case(kernel, pos.y, pos.x);
  if (!c)
    return ;
  dump_player_case(pos, cl, c, buffer);
  sprintf(buffer, "%s", buffer);
  while (i < ITEM_TYPE)
  {
    nb = 0;
    while (nb < c->inventory.items[i])
    {
      sprintf(buffer, "%s %s", buffer, g_item_names[i]);
      ++nb;
    }
    ++i;
  }
  sprintf(buffer, "%s,", buffer);
  write_socket(cl->fd, buffer);
}

static t_pos	get_dir(t_client *cl)
{
  t_pos		dir;

  dir.x = 0;
  dir.y = 0;
  if (cl->player->orientation == NORTH)
    dir.y--;
  else if (cl->player->orientation == SOUTH)
    dir.y++;
  else if (cl->player->orientation == EAST)
    dir.x++;
  else
    dir.x--;
  return (dir);
}

static void	check_line(t_kernel *kernel, t_pos init,
			   t_client *cl, int range)
{
  t_pos		pos;
  t_pos		dir;

  dir = get_dir(cl);
  if (range == cl->player->level + 1)
    return ;
  logger_debug("check_line range:%d", range);
  if (dir.y != 0)
  {
    pos.y = init.y + (dir.y * range);
    pos.x = init.x - range;
    dump_case(kernel, cl, pos);
    while (pos.x != init.x + range)
    {
      logger_debug("%d: ", range);
      dump_case(kernel, cl, pos);
      ++pos.x;
    }
    check_line(kernel, init, cl, range + 1);
  }
}

int		cmd_voir(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  check_line(kernel, cl->player->pos, cl, 0);
  write_socket(cl->fd, "\n");
  return (0);
}
