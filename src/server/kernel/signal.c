/*
** signal.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:32:08 2014 lefloc_l
** Last update sam. mai 17 18:22:41 2014 lefloc_l
*/

#include <stdlib.h>
#include <signal.h>
#include "map.h"
#include "utils.h"
#include "kernel.h"

extern t_map	g_map;

static void	signal_exit_prog(__attribute__((__unused__))int sig)
{
  delete_kernel();
  exit(EXIT_SUCCESS);
}

void	kernel_init_signals()
{
  if (signal(SIGQUIT, &signal_exit_prog) == SIG_ERR)
    mexit();
  if (signal(SIGINT, &signal_exit_prog) == SIG_ERR)
    mexit();
  if (signal(SIGTERM, &signal_exit_prog) == SIG_ERR)
    mexit();
}
