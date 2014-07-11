/*
** voir2.c for cmd in /home/loic/dev/epitech/c/Zappy/src/server/cmd
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 23:52:11 2014 lefloc_l
** Last update Fri Jul 11 04:08:25 2014 arnaud drain
*/

#include <string.h>
#include <stdlib.h>
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

char	*dump_case(t_kernel *kernel, t_client *cl, t_pos pos)
{
  t_case	*c;
  size_t	i;
  int		nb;
  char		buffer[BUFFER_SIZE] = {0};

  i = 0;
  c = get_case(kernel, pos.y, pos.x);
  if (!c)
    return (NULL);
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
  return (strdup(buffer));
}

char	*my_strcat(char *first, char *second, int do_free)
{
  if (!second)
    return (first);
  if (!(first = realloc(first,
          (strlen(first) + strlen(second) + 1) * sizeof(*first))))
    return (NULL);
  strcat(first, second);
  if (do_free)
    free(second);
  return (first);
}
