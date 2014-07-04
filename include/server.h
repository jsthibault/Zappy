/*
** serveur.h for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 18:42:10 2014 arnaud drain
** Last update Fri Jul  4 11:58:52 2014 arnaud drain
*/

#ifndef SERVEUR_H_
# define SERVEUR_H_

# include "kernel.h"
# include "options.h"
# include "player.h"
# include "utils.h"

/*
** size of the static buffers. never change !
*/
# define BUFFER_SIZE	(4096)

typedef enum
  {
    GRAPHIC = 0,
    CLIENT,
    AUTH
  } t_type;

typedef struct	s_functions
{
  char		*name;
  int		(*function)(char **, t_client *, t_kernel *);
  t_type	type;
  int		timeout;
}		t_functions;

char	**my_str_to_wordtab(char *str);
void	freetab(char **tab);
int	launch_srv(t_kernel *kernel);
int	return_error(char *str, int option);
int	write_socket(int fd, char *str);
int	init(size_t port);
int	add_client(int sfd, t_kernel *kernel);
void	pop_client(int fd, t_kernel *kernel);
int	graphic(char **, t_client *, t_kernel *);

#endif /* !SERVEUR_H_ */
