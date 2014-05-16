/*
** client_action.c for src in /home/loic/dev/epitech/c/Zappy/src
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:26:46 2014 lefloc_l
** Last update ven. mai 16 15:36:31 2014 lefloc_l
*/

#include <string.h>
#include <stdio.h>
#include "client_action.h"

static const t_tab_func	tab_func[] = {
  { "avance", &cmd_avance },
  { "droite", &cmd_droite },
  { "gauche", &cmd_gauche },
  { "voir", &cmd_voir },
  { "inventaire", &cmd_inventaire },
  { "prend objet", &cmd_prend_objet },
  { "pose object", &cmd_pose_objet },
  { "expulse", &cmd_expulse },
  { "broadcast texte", &cmd_broadcast_texte },
  { "incantation", &cmd_incantation },
  { "fork", &cmd_fork },
  { "connect_nbr", &cmd_connect_nbr},
  { NULL, NULL }
};

/*
** strlen - 1 because of \n after any command name
*/
char		*check_client_command(char *str)
{
  char		*res;
  size_t	i;

  for (i = 0; tab_func[i].p; i++)
  {
    if (!strncmp(tab_func[i].command, str, (strlen(tab_func[i].command) - 1)))
    {
      return (tab_func[i].p());
    }
  }
  fprintf(stderr, "Invalid command\n");
  return (NULL);
}

