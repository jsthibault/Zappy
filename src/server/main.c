/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update jeu. juil. 10 17:24:55 2014 lefloc_l
*/

#include <stdlib.h>
#include <time.h>
#include <signal.h>
#include "options.h"
#include "server.h"
#include "kernel.h"
#include "logger.h"
#include "list.h"

static t_kernel		*get_kernel(t_kernel *tmp_kernel)
{
  static t_kernel	*kernel = NULL;

  if (tmp_kernel)
    kernel = tmp_kernel;
  return (kernel);
}

static void	sig_signal(int sig)
{
  (void)sig;
  delete_kernel(get_kernel(NULL));
  exit(EXIT_SUCCESS);
}

int		main(const int argc, const char *argv[])
{
  t_kernel	kernel;

  signal(SIGINT, sig_signal);
  if (!logger_init("Zappy.log", TRUE))
    return (EXIT_FAILURE);
  if (!init_kernel(argc, argv, &kernel))
  {
    delete_kernel(&kernel);
    return (EXIT_FAILURE);
  }
  get_kernel(&kernel);
  srand(time(NULL));
  launch_srv(&kernel);
  delete_kernel(&kernel);
  return (EXIT_SUCCESS);
}
