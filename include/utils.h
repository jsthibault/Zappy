/*
** utils.h for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:25:01 2014 lefloc_l
** Last update mar. mai 13 16:46:42 2014 lefloc_l
*/

#ifndef UTILS_H_
# define UTILS_H_

/*
** Colors
*/

# define COLOR_BLUE	"\033[4;34m"
# define COLOR_GREEN	"\033[4;32m"
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

int		is_num(char *);
int		is_float(char *);

#endif /* !UTILS_H_ */
