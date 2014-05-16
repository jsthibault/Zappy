/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update ven. mai 16 17:51:53 2014 lefloc_l
*/

#include <signal.h>
#include <stdlib.h>
#include "options.h"
#include "map.h"
#include "logger.h"

t_map		g_map;

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

static void	signal_exit_prog(__attribute__((__unused__))int sig)
{
  int	i;
  int	j;

  for (i = 0; i < g_map.height; ++i)
  {
    for (j = 0; i < g_map.width; ++j)
    {
      // TODO free players list on g_map.map[i][j]
      free(g_map.map[i]);
    }
    free(g_map.map[i]);
  }

}

int		main(int argc, const char *argv[])
{
  t_options	options;

  if (signal(SIGQUIT, &signal_exit_prog) == SIG_ERR)
  {
    fprintf(stderr, "Signal failed.\n");
    return (EXIT_FAILURE);
  }

  init_options(&options);
  if (!parse_options(argc, argv, &options))
  {
    print_man();
    return (FALSE);
  }
  dump_options(&options);
//  init_map(options.width, options.height);
  logger_init("test.log", TRUE);
  return (0);
}
