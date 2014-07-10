/*
** game_auth.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. juil. 11 00:09:59 2014 lefloc_l
** Last update ven. juil. 11 00:13:19 2014 lefloc_l
*/

#include "server.h"

int		game_auth(char **av, t_client *client, t_kernel *kernel)
{
  t_team	*team;
  char		buf[15];

  if (av[0] && !client->graphic && !client->player)
    {
      if (!(client->player = init_player_with_teamname(kernel, av[0], client)))
	{
	  pop_client(client->fd, kernel);
	  freetab(av);
	  return (1);
	}
      team = find_team(kernel, av[0]);
      sprintf(buf, "%d\n%d %d\n", team->place_left,
	      (int)kernel->options.width, (int)kernel->options.height);
      write_socket(client->fd, buf);
    }
  else if (client->graphic)
    write_socket(client->fd, "suc\n");
  freetab(av);
  return (0);
}
