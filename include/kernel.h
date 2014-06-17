/*
** kernel.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:34:27 2014 lefloc_l
** Last update Tue Jun 17 13:54:01 2014 arnaud drain
*/

#ifndef KERNEL_H_
# define KERNEL_H_

# include "options.h"
# include "game.h"
# include "utils.h"
# include "struct.h"

t_bool		init_kernel(const int, const char **, t_kernel *);
void		delete_kernel(t_kernel *);
void		kernel_init_signals();
void		run_kernel();

#endif /* !KERNEL_H_ */
