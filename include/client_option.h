/*
** client_option.h for client_option in /home/canque_r/Zappy/src/client_ia
**
** Made by Rodrigue Canquery
** Login   <canque_r@Ubuntu-laptop>
**
** Started on  Sun Jul  6 09:18:33 2014 Rodrigue Canquery
** Last update jeu. juil. 10 22:31:58 2014 lefloc_l
*/

#ifndef CLIENT_OPTION_H_
# define CLIENT_OPTION_H_

# include <stddef.h>

typedef enum	e_bool
{
  FALSE,
  TRUE
}		t_bool;

typedef struct	s_option
{
  size_t	port;
  char		host[100];
  char		team[100];
}		t_option;

typedef struct	s_tabfunctions
{
  char		*option;
  t_bool	(*p)();
}		t_tabfunctions;

t_bool	parse_option(int ac, char *av[], t_option *option);
t_bool	convert_to_int(char *av[], int ac, int *i, size_t *n);
t_bool	option_n(char **, int, int *, t_option *);
t_bool	option_p(char **, int, int *, t_option *);
t_bool	option_h(char **, int, int *, t_option *);
t_bool	is_num(char *);
int	init_client(t_option *option);

#endif /* !CLIENT_OPTION_H_ */
