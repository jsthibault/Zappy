/*
** server_command.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. juil. 11 00:10:54 2014 lefloc_l
** Last update ven. juil. 11 00:14:05 2014 lefloc_l
*/

#include <string.h>
#include "server.h"
#include "client_action.h"

static const t_functions g_functions[] =
    {
      {"GRAPHIC", graphic, AUTH, 0},
      {"msz", msz, GRAPHIC, 0},
      {"bct", bct, GRAPHIC, 0},
      {"mct", mct, GRAPHIC, 0},
      {"tna", tna, GRAPHIC, 0},
      {"ppo", ppo, GRAPHIC, 0},
      {"plv", plv, GRAPHIC, 0},
      {"pin", pin, GRAPHIC, 0},
      {"sgt", sgt, GRAPHIC, 0},
      {"sst", sst, GRAPHIC, 0},
      {"avance", cmd_avance, CLIENT, 7},
      {"gauche", cmd_gauche, CLIENT, 7},
      {"droite", cmd_droite, CLIENT, 7},
      {"pose_objet", cmd_pose_objet, CLIENT, 7},
      {"prend_objet", cmd_prend_objet, CLIENT, 7},
      {"inventaire", cmd_inventaire, CLIENT, 1},
      {"voir", cmd_voir, CLIENT, 7},
      {"prend", cmd_prend_objet, CLIENT, 7},
      {"pose", cmd_pose_objet, CLIENT, 7},
      {"expulse", cmd_expulse, CLIENT, 7},
      {"broadcast", cmd_broadcast_texte, CLIENT, 7},
      {"incantation", cmd_incantation, CLIENT, 0},
      {"fork", cmd_fork, CLIENT, 0},
      {"connect_nbr", cmd_connect_nbr, CLIENT, 0},
      {"elevation", incantation, SPECIAL, 0},
      {"pond", cmd_pond, SPECIAL, 0},
      {NULL, NULL, AUTH, 0}
    };

static char	*find_end(char *line)
{
  while (line && *line && *line != '\n' && *line != '\r')
    ++line;
  while (line && (*line == '\n' || *line == '\r'))
    ++line;
  return (line);
}

static int	call_cmd(int i, t_client *client, char **av, t_kernel *kernel)
{
  int		ret;

  if (g_functions[i].type == CLIENT && client->player)
    {
      if (FALSE == add_action(g_functions[i].timeout, client->player, av, 0))
	ret = -1;
    }
  else if ((g_functions[i].type == GRAPHIC && client->graphic) ||
	   (g_functions[i].type == AUTH && !(client->graphic) &&
	    !(client->player)))
    {
      ret = g_functions[i].function(av, client, kernel);
      freetab(av);
    }
  if (ret)
    return (ret);
  return (0);
}

static int	launch_cmd(char *line, t_client *client, t_kernel *kernel)
{
  char		**av;
  int		i;
  int		ret;

  while (line && *line)
    {
      if (!(av = my_str_to_wordtab(line)))
	return (-1);
      i = 0;
      ret = -1;
      while (ret == -1 && av[0] && g_functions[i].name)
	{
	  if (!strcmp(av[0], g_functions[i].name))
	    {
	      if ((ret = call_cmd(i, client, av, kernel)))
		return (ret);
	    }
	  ++i;
	}
      if (!g_functions[i].name)
	if ((ret = game_auth(av, client, kernel)))
	  return (ret);
      line = find_end(line);
    }
  return (0);
}

int	cmd_client(t_client *client, t_kernel *kernel,
		   t_buffer *buff_node)
{
  char	*buffer;

  buffer = read_on(client->fd, buff_node);
  if (buffer == NULL)
    return (-1);
  else if (buffer == (void *)2)
    {
      printf("[\033[31;1mOK\033[0m] Deconnection from %s\n", client->ip);
      pop_client(client->fd, kernel);
      return (1);
    }
  printf("[\033[32;1mClient %s\033[0m] msg : [%s]\n", client->ip, buffer);
  return (launch_cmd(buffer, client, kernel));
}

int	launch_action(t_actions *action, t_player *player,
    t_kernel *kernel)
{
  int	i;

  i = 0;
  while (action->av[0] && g_functions[i].name &&
	 strcmp(action->av[0], g_functions[i].name))
    ++i;
  if (action->av[0] && g_functions[i].name)
    if (g_functions[i].function(action->av, player->client, kernel))
      return (-1);
  freetab(action->av);
  list_pop(&(player->actions), action);
  return (0);
}
