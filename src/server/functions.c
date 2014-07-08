/*
** functions.c for functions in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Sat Apr 19 14:20:12 2014 arnaud drain
** Last update Tue Jul  8 17:15:35 2014 arnaud drain
*/

#include <string.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include "client_action.h"
#include "server.h"

t_bool	send_message(int fd, char *msg)
{
  write_socket(fd, msg);
  return (TRUE);
}

t_bool	pnw(int fd, t_player *player)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pnw %d %d %d %d %d %s\n", player->id,
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

  sprintf(res, "pex %d\n", player_id);
  return (send_message(fd, res));
}

t_bool	enw(int fd, int egg, int player_id, t_pos pos)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "enw %d %d %d %d\n", egg, player_id, pos.x, pos.y);
  return (send_message(fd, res));
}

t_bool	ebo(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "ebo %d\n", egg);
  return (send_message(fd, res));
}

t_bool	eht(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "eht %d\n", egg);
  return (send_message(fd, res));
}

t_bool	edi(int fd, int egg)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "edi %d\n", egg);
  return (send_message(fd, res));
}

t_bool	pgt(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pgt %d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}

t_bool	pdr(int fd, int player_id, int ressource_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pdr %d %d\n", player_id, ressource_id);
  return (send_message(fd, res));
}

t_bool	pdi(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pdi %d\n", player_id);
  return (send_message(fd, res));
}

t_bool	pfk(int fd, int player_id)
{
  char	res[BUFFER_SIZE];

  sprintf(res, "pfk %d\n", player_id);
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

static int	print_bct(int fd, t_case *map_case, int x, int y)
{
  char		buf[BUFFER_SIZE];
  int		*items;

  items = map_case->inventory.items;
  sprintf(buf, "bct %d %d %d %d %d %d %d %d %d\n", x, y, items[0],
	  items[1], items[2], items[3], items[4], items[5], items[6]);
  return (write_socket(fd, buf));
}

static int	sbp(int fd)
{
  if (write_socket(fd, "sbp\n") <= 0)
    return (1);
  return (0);
}

int	ko(int fd)
{
  if (write_socket(fd, "ko\n") <= 0)
    return (1);
  return (0);
}

int	bct(char **av, t_client *cl, t_kernel *kernel)
{
  t_pos	pos;

  if (av_length(av) != 3)
    return (sbp(cl->fd));
  pos.x = atoi(av[1]);
  pos.y = atoi(av[2]);
  if (print_bct(cl->fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y) <= 0)
    return (1);
  return (0);
}

static int	print_mct(int fd, t_kernel *kernel)
{
  t_pos		pos;

  for (pos.y = 0; pos.y < kernel->game.map->height; ++pos.y)
    {
      for (pos.x = 0; pos.x < kernel->game.map->width; ++pos.x)
	{
	  if (print_bct(fd, get_case(kernel, pos.y, pos.x), pos.x, pos.y) <= 0)
	    return (-1);
	}
    }
  return (0);
}

int	mct(char **av, t_client *cl, t_kernel *kernel)
{
  (void)av;
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  return (0);
}

int		print_players(int fd, t_kernel *kernel)
{
  t_node	*node;

  if (!(kernel->game.players))
    return (0);
  node = kernel->game.players->head;
  while (node)
    {
      if (pnw(fd, ((t_player *)(node->data))) <= 0)
	return (-1);
      node = node->next;
    }
  return (0);
}

int	graphic(char **av, t_client *cl, t_kernel *kernel)
{
  char	buf[BUFFER_SIZE];

  (void)av;
  if (cl->player)
    return (0);
  cl->graphic = TRUE;
  sprintf(buf, "msz %d %d\n", (int)kernel->options.width, (int)kernel->options.height);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  sprintf(buf, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buf) <= 0)
    return (1);
  if (print_mct(cl->fd, kernel) < 0)
    return (1);
  if (print_tna(cl->fd, kernel) < 0)
    return (1);
  if (print_players(cl->fd, kernel) < 0)
    return (1);
  // liste des oeufs
  return (0);
}

int	msz(char **av, t_client *cl, t_kernel *kernel)
{
  char  buff[BUFFER_SIZE];
  int   x;
  int   y;

  (void)av;
  x = kernel->options.width;
  y = kernel->options.height;
  sprintf(buff, "msz %d %d\n", x, y);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}

int		print_tna(int fd, t_kernel *kernel)
{
  char          buff[BUFFER_SIZE];
  t_node        *tempory_team;

  if (!(kernel->game.teams))
    return (0);
  tempory_team = kernel->game.teams->head;
  while (tempory_team)
    {
      memset(buff, 0, BUFFER_SIZE);
      sprintf(buff, "tna %s\n", ((t_team *)tempory_team->data)->name);
      if (write_socket(fd, buff) <= 0)
        return (-1);
      tempory_team = tempory_team->next;
    }
  return (0);
}

int		tna(char **av, t_client *cl, t_kernel *kernel)
{
  char          buff[BUFFER_SIZE];
  t_node        *tempory_team;

  (void)av;
  if (!(kernel->game.teams))
    return (0);
  tempory_team = kernel->game.teams->head;
  while (tempory_team)
    {
      memset(buff, 0, BUFFER_SIZE);
      sprintf(buff, "tna %s\n", ((t_team *)tempory_team->data)->name);
      if (write_socket(cl->fd, buff) <= 0)
        return (1);
      tempory_team = tempory_team->next;
    }
  return (0);
}

int		ppo(char **av, t_client *cl, t_kernel *kernel)
{
  int           nb_player;
  t_player      *tempory_player;
  char          buff[BUFFER_SIZE];

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  nb_player = atoi(av[1]);
  if (!(tempory_player = get_player_by_id(nb_player, kernel->game.players)))
    return (sbp(cl->fd));
  sprintf(buff, "ppo %d %d %d %d\n", nb_player, tempory_player->pos.x,
	  tempory_player->pos.y, tempory_player->orientation);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}

int		plv(char **av, t_client *cl, t_kernel *kernel)
{
  int           nb_player;
  t_player      *tempory_player;
  char          buff[BUFFER_SIZE];

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  nb_player = atoi(av[1]);
  if (!(tempory_player = get_player_by_id(nb_player, kernel->game.players)))
    return (sbp(cl->fd));
  sprintf(buff, "plv %d %d\n", nb_player, tempory_player->level);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}

int		pin(char **av, t_client *cl, t_kernel *kernel)
{
  int           nb_player;
  t_player      *tmp_player;
  char          buff[BUFFER_SIZE];
  int		*items;

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  nb_player = atoi(av[1]);
  if (!(tmp_player = get_player_by_id(nb_player, kernel->game.players)))
    return (sbp(cl->fd));
  items = tmp_player->inventory.items;
  sprintf(buff, "pin %d %d %d %d %d %d %d %d %d %d\n", nb_player,
	  tmp_player->pos.x, tmp_player->pos.y, items[0], items[1],
	  items[2], items[3], items[4], items[5], items[6]);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}

int		sgt(char **av, t_client *cl, t_kernel *kernel)
{
  char          buff[BUFFER_SIZE];

  (void)av;
  sprintf(buff, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}

int		sst(char **av, t_client *cl, t_kernel *kernel)
{
  char          buff[BUFFER_SIZE];
  int           new_delai;

  if (av_length(av) != 2)
    return (sbp(cl->fd));
  new_delai = atoi(av[1]);
  if (new_delai <= 0)
    return (sbp(cl->fd));
  kernel->options.delai = new_delai;
  sprintf(buff, "sgt %d\n", (int)kernel->options.delai);
  if (write_socket(cl->fd, buff) <= 0)
    return (1);
  return (0);
}
