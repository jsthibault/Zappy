/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update Mon Jun 16 15:45:08 2014 arnaud drain
*/

#include <stdlib.h>
#include "options.h"
#include "server.h"
#include "kernel.h"
#include "logger.h"
#include "list.h"

static void	print_man()
{
  fprintf(stderr, "%sUsage:%s\n \
      -p numero de port\n \
      -x largeur du Monde\n \
      -y hauteur du Monde\n \
      -n nom_de_equipe_1 nom_de_equipe_2 ...\n \
      -c nombre de clients par équipe autorisés au commencement du jeu \n \
      -t delai temporel d’execution des actions\n", COLOR_BLUE, COLOR_NORMAL);
}

int		main(const int argc, const char *argv[])
{
  t_options	options;

  /*logger_init("test.log", TRUE);*/
  if (!init_kernel(argc, argv))
  {
    print_man();
    delete_kernel();
    return (EXIT_FAILURE);
  }
  /*dump_options(&options);*/
  init_options(&options);
  launch_srv(&options);
  /*run_kernel();
    delete_kernel();*/
  return (EXIT_SUCCESS);
}
