/*
** init_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:35:55 2014 lefloc_l
** Last update jeu. juil. 10 23:35:09 2014 lefloc_l
*/

#include <stdlib.h>
#include "logger.h"
#include "kernel.h"
#include "options.h"
#include "map.h"

static void	print_man()
{
  fprintf(stderr, "%sUsage:%s\n \
      -p numero de port\n \
      -x largeur du Monde\n \
      -y hauteur du Monde\n \
      -n nom_de_equipe_1 nom_de_equipe_2 ...\n \
      -c nombre de clients par équipe autorisés au commencement du jeu \n \
      -t delai temporel d’execution des actions\n",
	  COLOR_BLUE, COLOR_NORMAL);
}

t_bool	init_kernel(const int argc, const char **argv, t_kernel *kernel)
{
  logger_message("{KERNEL} Initialisation");
  kernel->clients = NULL;
  kernel->sfd = 0;
  if (FALSE == pre_fill_game(kernel))
    return (FALSE);
  init_options(&(kernel->options));
  if (!parse_options(argc, argv, &(kernel->options)))
  {
    print_man();
    return (FALSE);
  }
  dump_options(&(kernel->options));
  if (FALSE == init_game(kernel))
    return (FALSE);
  return (TRUE);
}
