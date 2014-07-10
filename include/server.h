/*
** serveur.h for serveur in /home/drain_a/rendu/PSU_2013_myirc
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Fri Apr 18 18:42:10 2014 arnaud drain
** Last update ven. juil. 11 00:15:04 2014 lefloc_l
*/

#ifndef SERVEUR_H_
# define SERVEUR_H_

# include <sys/select.h>
# include <sys/time.h>
# include <sys/types.h>
# include <sys/socket.h>
# include <netinet/in.h>
# include <arpa/inet.h>
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
    AUTH,
    SPECIAL
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
void	write_all_graphic(t_kernel *, char *);
int	launch_action(t_actions *, t_player *, t_kernel *);
int	game_auth(char **av, t_client *client, t_kernel *kernel);
int	cmd_client(t_client *, t_kernel *, t_buffer *);
int	init_select(fd_set *, int, t_client *);

#endif /* !SERVEUR_H_ */
