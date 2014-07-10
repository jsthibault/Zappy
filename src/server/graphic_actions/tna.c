/*
** tna.c for reseau in /home/loic/dev/epitech/c/Zappy/src/server/reseau
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  jeu. juil. 10 22:44:42 2014 lefloc_l
** Last update jeu. juil. 10 23:02:43 2014 lefloc_l
*/

#include <string.h>
#include "client_action.h"
#include "struct.h"

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
