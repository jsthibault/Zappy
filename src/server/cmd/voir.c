/*
** voir.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 17:38:33 2014 lefloc_l
** Last update jeu. juil. 10 23:53:42 2014 lefloc_l
*/

#include <string.h>
#include <stdlib.h>
#include "client_action.h"
#include "server.h"
#include "utils.h"
#include "enum.h"
#include "map.h"
#include "logger.h"

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

static char	*check_line(t_kernel *kernel, t_pos init,
			   t_client *cl, int range)
{
  char		*buffer;
  char		*tmp;
  t_pos		pos;
  t_pos		dir;
  int		i;

  if (!(buffer = strdup("")))
    return (NULL);
  if (range == cl->player->level + 1)
    return (buffer);
  get_vec(cl->player->orientation, &dir);
  pos.y = init.y - (dir.y * range);
  pos.x = init.x - (dir.x * range);
  i = 0;
  while (i < (range * 2 + 1))
    {
      if (!(tmp = dump_case(kernel, cl, pos)) ||
	  !(buffer = my_strcat(buffer, tmp, 1)))
	return (NULL);
      pos.y += dir.y;
      pos.x += dir.x;
      ++i;
      if ((range < (cl->player->level) || i < (range * 2 + 1)) &&
	  !(buffer = my_strcat(buffer, ",", 0)))
	return (NULL);
    }
  init.x += dir.y;
  init.y -= dir.x;
  if (!(tmp = check_line(kernel, init, cl, range + 1)))
    {
      free(buffer);
      return (NULL);
    }
  return (my_strcat(buffer, tmp, 1));
}

int		cmd_voir(char **av, t_client *cl, t_kernel *kernel)
{
  char		*buffer;
  char		*buffer_tmp;

  (void)av;
  if (!(buffer = strdup("{")))
    return (-1);
  if (!(buffer_tmp = check_line(kernel, cl->player->pos, cl, 0)))
    return (-1);
  if (!(buffer = my_strcat(buffer, buffer_tmp, 1)))
    return (-1);
  if (!(buffer = my_strcat(buffer, "}\n", 0)))
    return (-1);
  if (write_socket(cl->fd, buffer) <= 0)
    return (1);
  free(buffer);
  return (0);
}
