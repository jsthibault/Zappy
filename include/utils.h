/*
** utils.h for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:25:01 2014 lefloc_l
** Last update mar. mai 13 16:17:38 2014 lefloc_l
*/

#ifndef UTILS_H_
# define UTILS_H_

/*
**
*/

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
