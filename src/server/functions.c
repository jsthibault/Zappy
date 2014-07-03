/*
** functions.c for functions in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Sat Apr 19 14:20:12 2014 arnaud drain
** Last update Thu Jul  3 15:53:51 2014 arnaud drain
*/

#include <string.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include "server.h"

t_bool	send_message(int fd, char *msg)
{
  write_socket(fd, msg);
  return (TRUE);
}

t_bool	pnw(int fd, t_player *player)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pnw #%d %d %d %d %d %s", player->id,
      player->pos.x, player->pos.y,
      player->orientation, player->level, player->team->name);
  return (send_message(fd, res));

}

t_bool	pie(int fd, t_pos pos, int result)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pie %d %d %d\n", pos.x, pos.y, result);
  return (send_message(fd, res));
}

t_bool	pex(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pex #%d\n", player_id);
  return (send_message(fd, res));
}

t_bool	enw(int fd, int egg, int player_id, t_pos pos)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "enw #%d #%d %d %d\n", egg, player_id, pos.x, pos.y);
  return (send_message(fd, res));
}

t_bool	ebo(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "ebo #%d\n", egg);
  return (send_message(fd, res));
}

t_bool	eht(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "eht #%d\n", egg);
  return (send_message(fd, res));
}

t_bool	edi(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "edi #%d\n", egg);
  return (send_message(fd, res));
}

t_bool	pgt(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pgt #%d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}

t_bool	pdr(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pdr #%d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}

t_bool	pdi(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pdi #%d\n", player_id);
  return (send_message(fd, res));
}

t_bool	pfk(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pfk #%d\n", player_id);
  return (send_message(fd, res));
}

t_bool	seg(int fd, char *winner)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "seg %s", winner);
  if (winner[strlen(winner)] != '\n')
    strcat(res, "\n");
  return (send_message(fd, res));
}

t_bool	smg(int fd, char *msg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "smg %s", msg);
  if (msg[strlen(msg)] != '\n')
    strcat(res, "\n");
  return (send_message(fd, res));
}

t_bool	suc(int fd)
{
  write_socket(fd, "suc");
  return (TRUE);
}

t_bool	sbp(int fd)
{
  write_socket(fd, "sbp");
  return (TRUE);
}

static int	print_bct(int fd, t_case *map_case, int x, int y)
{
  char		buf[1024];
  int		*items;

  items = map_case->inventory.items;
  sprintf(buf, "bct %d %d %d %d %d %d %d %d %d\n", x, y, items[0],
	  items[1], items[2], items[3], items[4], items[5], items[6]);
  printf("write !\n");
  return (write_socket(fd, buf));
}

static int	print_mct(int fd, t_kernel *kernel)
{
  t_pos		pos;

  for (pos.y = 0; pos.y < kernel->game.map->height; ++pos.y)
    {
      for (pos.x = 0; pos.x < kernel->game.map->width; ++pos.x)
	{
	  int test;
	  test = print_bct(fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y);
	  printf("x : %d y : %d %d\n", pos.x, pos.y, test);
	  if (test <= 0)
	    return (-1);
	}
    }
  return (0);
}

int	graphic(char **av, t_client *cl, t_kernel *kernel)
{
  char	buf[1024];

  (void)av;
  if (cl->player)
    return (0);
  cl->graphic = TRUE;
  if (write_socket(cl->fd, "BIENVENUE\n") <= 0)
    return (1);
  sprintf(buf, "msz %d %d\n", (int)kernel->options.width, (int)kernel->options.height);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  printf("the end\n");
  return (0);
}
