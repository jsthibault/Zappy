/*
** client_action.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:27:40 2014 lefloc_l
** Last update Mon Jul  7 01:07:41 2014 arnaud drain
*/

#ifndef CLIENT_ACTION_H_
# define CLIENT_ACTION_H_

#include "struct.h"
#include "server.h"

typedef struct	e_tab_func
{
  char		*command;
  int		(*p)(char **av, t_client *, t_kernel *kernel);
}		t_tab_func;

int		add_action(t_kernel *, int, t_client *, char **);
int		graphic(char **, t_client *, t_kernel *);

/*
** Functions to call when event is catch.
*/
void		send_position_to_graphic(t_kernel *, t_player *);
void		send_prend_to_graphic(t_kernel *, t_player *, int);
void		send_pose_to_graphic(t_kernel *, t_player *, int);
void		send_deconnexion_to_graphic(t_kernel *, t_player *);
void		send_connexion_to_graphic(t_kernel *, t_player *);
void		send_egg_connexion_to_graphic(t_kernel *, t_player *, int);

/*
** grahic print functions.
*/
int		print_tna(int fd, t_kernel *kernel);

/*
** graphic command.
*/
int		msz(char **, t_client *, t_kernel *);
int		bct(char **, t_client *, t_kernel *);
int		mct(char **, t_client *, t_kernel *);
int		tna(char **, t_client *, t_kernel *);
int		ppo(char **, t_client *, t_kernel *);
int		plv(char **, t_client *, t_kernel *);
int		pin(char **, t_client *, t_kernel *);
int		sgt(char **, t_client *, t_kernel *);
int		sst(char **, t_client *, t_kernel *);
t_bool		pnw(int, t_player *);
t_bool		pie(int, t_pos, int);
t_bool		pex(int, int);
t_bool		enw(int, int, int, t_pos);
t_bool		ebo(int, int);
t_bool		eht(int, int);
t_bool		edi(int, int);
t_bool		pgt(int, int, int);
t_bool		pdr(int, int, int);
t_bool		pdi(int, int);
t_bool		pfk(int, int);
t_bool		seg(int, char *);
t_bool		smg(int, char *);

/*
** client command.
*/
int		cmd_avance(char **av, t_client *, t_kernel *kernel);
int		cmd_droite(char **av, t_client *, t_kernel *kernel);
int		cmd_gauche(char **av, t_client *, t_kernel *kernel);
int		cmd_voir(char **av, t_client *, t_kernel *kernel);
int		cmd_inventaire(char **av, t_client *, t_kernel *kernel);
int		atoi_objet(char *objet);
int		cmd_prend_objet(char **av, t_client *, t_kernel *kernel);
int		cmd_pose_objet(char **av, t_client *, t_kernel *kernel);
int		cmd_expulse(char **av, t_client *, t_kernel *kernel);
int		cmd_broadcast_texte(char **av, t_client *, t_kernel *kernel);
int		cmd_incantation(char **av, t_client *, t_kernel *kernel);
int		cmd_fork(char **av, t_client *, t_kernel *kernel);
int		cmd_connect_nbr(char **av, t_client *, t_kernel *kernel);

#endif /* !CLIENT_ACTION_H_ */
