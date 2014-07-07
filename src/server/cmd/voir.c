/*
** voir.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:33 2014 lefloc_l
<<<<<<< HEAD
** Last update Mon Jul  7 18:20:09 2014 arnaud drain
||||||| merged common ancestors
** Last update lun. juil. 07 15:17:58 2014 lefloc_l
=======
** Last update lun. juil. 07 15:17:58 2014 lefloc_l
>>>>>>> 04438f3006363055e0a474fd1e56af9cc8bb1dc3
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
    sprintf(buffer, "%s%s ", buffer, "player");
    --nb;
  }
}

static void	dump_case(t_kernel *kernel, t_client *cl, t_pos pos)
{
  t_case	*c;
  size_t	i;
  int		nb;
  char		buffer[BUFFER_SIZE] = {0};

  i = 0;
  logger_debug("%d %d\n", pos.x, pos.y);
  c = get_case(kernel, pos.y, pos.x);
  if (!c)
    return ;
  dump_player_case(pos, cl, c, buffer);
  while (i < ITEM_TYPE)
  {
    nb = 0;
    while (nb < c->inventory.items[i])
    {
      sprintf(buffer, "%s%s ", buffer, g_item_names[i]);
      ++nb;
    }
    ++i;
  }
  buffer[strlen(buffer) - 1] = 0;
  write_socket(cl->fd, buffer);
}

static void	get_vec(t_orientation orientation, t_pos *dir)
{
  dir->x = 0;
  dir->y = 0;
  if (orientation == NORTH)
    dir->x = 1;
  else if (orientation == SOUTH)
    dir->x = -1;
  else if (orientation == EAST)
    dir->y = 1;
  else
    dir->y = -1;
}

static int	check_line(t_kernel *kernel, t_pos init,
			   t_client *cl, int range)
{
  t_pos		pos;
  t_pos		dir;
  int		i;

  if (range == cl->player->level + 1)
    return (0);
  get_vec(cl->player->orientation, &dir);
  logger_debug("check_line range:%d", range);
  pos.y = init.y - (dir.y * range);
  pos.x = init.x - (dir.x * range);
  i = 0;
  while (i < (range * 2 + 1))
    {
      dump_case(kernel, cl, pos);
      pos.y += dir.y;
      pos.x += dir.x;
      ++i;
      if (range < (cl->player->level) || i < (range * 2 + 1))
	write_socket(cl->fd, ",");
    }
  init.x += dir.y;
  init.y -= dir.x;
  return (check_line(kernel, init, cl, range + 1));
}

int		cmd_voir(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  if (write_socket(cl->fd, "{") <= 0)
    return (1);
  if (check_line(kernel, cl->player->pos, cl, 0))
    return (1);
  if (write_socket(cl->fd, "}\n") <= 0)
    return (1);
  return (0);
}
