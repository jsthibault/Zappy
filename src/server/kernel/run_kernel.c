/*
** run_kernel.c for kernel in /home/loic/dev/epitech/c/Zappy/src/server/kernel
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:44:07 2014 lefloc_l
** Last update Tue Jun 17 15:50:51 2014 arnaud drain
*/

#include <unistd.h>
#include "kernel.h"
#include "logger.h"

void	run_kernel(t_kernel *kernel)
{
  (void)kernel;
  logger_message("{KERNEL} Starting");
  /*  while (kernel->is_running == TRUE)
  {
    gestion des connexions clients etc.
    sleep(1);
  }*/
}
