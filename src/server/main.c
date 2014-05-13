/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update mar. mai 13 16:51:36 2014 lefloc_l
*/

#include "options.h"

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

int		main(int argc, const char *argv[])
{
  t_options	options;

  init_options(&options);
  if (!parse_options(argc, argv, &options))
  {
    print_man();
    return (FALSE);
  }
  dump_options(&options);
  return (0);
}
