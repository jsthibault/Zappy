/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update sam. mai 17 17:47:39 2014 lefloc_l
*/

#include <stdlib.h>
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

void	dump(void *data)
{
  if (data)
    printf("%s\n", data);
  else
    printf("Empty\n");
}

int		main(const int argc, const char *argv[])
{
  logger_init("test.log", TRUE);
  if (FALSE == init_kernel(argc, argv))
  {
    print_man();
    return (EXIT_FAILURE);
  }

//  run_kernel();
  return (EXIT_SUCCESS);
}
