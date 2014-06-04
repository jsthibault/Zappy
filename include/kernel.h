/*
** kernel.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 13:34:27 2014 lefloc_l
** Last update sam. mai 17 17:34:57 2014 lefloc_l
*/

#ifndef KERNEL_H_
# define KERNEL_H_

# include "options.h"
# include "utils.h"
# include "game.h"

typedef struct	s_kernel
{
  t_options	options;
  t_game	*game;
  t_bool	is_running;
}		t_kernel;

t_bool		init_kernel(const int, const char **);
void		delete_kernel();
void		kernel_init_signals();
void		run_kernel();

#endif /* !KERNEL_H_ */
