/*
** init_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:35:55 2014 lefloc_l
** Last update Fri Jul  4 17:05:20 2014 arnaud drain
*/

#include <stdlib.h>
#include "logger.h"
#include "kernel.h"
#include "options.h"
#include "map.h"

t_bool		init_kernel(const int argc, const char **argv, t_kernel *kernel)
{
  logger_message("{KERNEL} Initialisation");
  kernel->actions = NULL;
  kernel->clients = NULL;
  pre_fill_game(kernel);
  init_options(&(kernel->options));
  if (!parse_options(argc, argv, &(kernel->options)))
    return (FALSE);
  dump_options(&(kernel->options));
  init_game(kernel);
  return (TRUE);
}
