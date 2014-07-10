/*
** options.h for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 13:59:34 2014 lefloc_l
** Last update jeu. juil. 10 22:33:16 2014 lefloc_l
*/

#ifndef OPTIONS_H_
# define OPTIONS_H_

# include <stdio.h>
# include "utils.h"
# include "list.h"
# include "struct.h"

/*
** Define for default options
*/

# define DEFAULT_PORT		4242
# define DEFAULT_WIDTH		30
# define DEFAULT_HEIGHT		30
# define DEFAULT_MAX_CLIENTS	10
# define DEFAULT_DELAI		100

typedef struct	s_tabfunctions
{
  char		*option;
  t_bool	(*p)();
}		t_tabfunctions;

void		init_options(t_options *);
t_bool		parse_options(const int, const char **, t_options *);
void		dump_options(t_options *options);
t_bool	convert_to_int(char *av[], int ac, int *i, size_t *n);

/*
** functions for each option.
*/

t_bool	option_p(char **, int, int *, t_options *);
t_bool	option_x(char **, int, int *, t_options *);
t_bool	option_y(char **, int, int *, t_options *);
t_bool	option_c(char **, int, int *, t_options *);
t_bool	option_n(char **, int, int *, t_options *);
t_bool	option_t(char **, int, int *, t_options *);

#endif /* !OPTIONS_H_ */
