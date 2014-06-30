/*
** delete_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:33:47 2014 lefloc_l
** Last update Fri Jun 27 20:52:28 2014 arnaud drain
*/

#include <stdlib.h>
#include "kernel.h"
#include "map.h"
#include "logger.h"

void	delete_kernel(t_kernel *kernel)
{
  delete_game(kernel);
  logger_message("{KERNEL} Deleted");
}
