/*
** delete_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:33:47 2014 lefloc_l
** Last update sam. mai 17 17:36:26 2014 lefloc_l
*/

#include <stdlib.h>
#include "kernel.h"
#include "map.h"
#include "logger.h"

extern t_kernel	*g_kernel;

void	delete_kernel()
{
  logger_message("{KERNEL} Delete");
  if (g_kernel)
  {
    delete_game();
    free(g_kernel);
  }
}
