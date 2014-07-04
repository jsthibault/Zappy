/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
<<<<<<< HEAD
** Last update ven. juil. 04 17:19:20 2014 lefloc_l
||||||| merged common ancestors
** Last update Fri Jul  4 16:17:34 2014 arnaud drain
=======
** Last update Fri Jul  4 17:10:01 2014 arnaud drain
>>>>>>> ff89b2a7cec83a385250e382371d5d16520bb1e2
*/

#include <signal.h>
#include <stdlib.h>
#include <time.h>
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
      -t delai temporel d’execution des actions\n",
	  COLOR_BLUE, COLOR_NORMAL);
}

static void	sigtruc(int sig)
{
  (void)sig;
  printf("SIGPIPE\n");
  logger_delete();
  exit(EXIT_FAILURE);
}

int		main(const int argc, const char *argv[])
{
  t_kernel	kernel;

  signal(SIGPIPE, sigtruc);
  signal(SIGINT, sigtruc);
  if (!logger_init("test.log", TRUE))
    return (EXIT_FAILURE);
  if (!init_kernel(argc, argv, &kernel))
    {
      print_man();
      delete_kernel(&kernel);
      return (EXIT_FAILURE);
    }
  srand(time(NULL));
  launch_srv(&kernel);
  delete_kernel(&kernel);
  return (EXIT_SUCCESS);
}
