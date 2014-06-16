/*
** init_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:35:55 2014 lefloc_l
** Last update Mon Jun 16 15:55:30 2014 arnaud drain
*/

#include <stdlib.h>
#include "logger.h"
#include "kernel.h"
#include "options.h"
#include "map.h"

t_kernel	*g_kernel = NULL;

t_bool		init_kernel(const int argc, const char **argv)
{
  g_kernel = xmalloc(sizeof(t_kernel));
  kernel_init_signals();
  logger_message("{KERNEL} Initialisation");
  init_options(&g_kernel->options);
  if (!parse_options(argc, argv, &g_kernel->options))
    return (FALSE);
  dump_options(&g_kernel->options);
  g_kernel->is_running = TRUE;
  init_game();
  return (TRUE);
}
