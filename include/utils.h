/*
** utils.h for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:25:01 2014 lefloc_l
** Last update Thu Jul  3 16:51:22 2014 arnaud drain
*/

#ifndef UTILS_H_
# define UTILS_H_

# include <stdio.h>

/*
** Colors
*/

# define COLOR_BLUE	"\033[4;34m"
# define COLOR_GREEN	"\033[4;32m"
# define COLOR_YELLOW	"\033[4;33m"
# define COLOR_RED	"\033[4;31m"
# define COLOR_NORMAL	"\033[0m"

typedef enum	e_bool
{
  FALSE,
  TRUE
}		t_bool;

/*
** Useful functions.
*/

int		av_length(char **av);
t_bool		is_num(char *);
t_bool		is_float(char *);
void		*xmalloc(size_t size);
void		print_error(char *str);
void		mexit();

#endif /* !UTILS_H_ */
