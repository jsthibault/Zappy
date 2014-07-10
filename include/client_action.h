/*
** client_action.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:27:40 2014 lefloc_l
** Last update jeu. juil. 10 23:15:53 2014 lefloc_l
*/

#ifndef CLIENT_ACTION_H_
# define CLIENT_ACTION_H_

# include "struct.h"
# include "server.h"

# define MAX_LVL	7

typedef struct	s_tab_func
{
  char		*command;
  int		(*p)(char **av, t_client *, t_kernel *kernel);
}		t_tab_func;

typedef struct	s_incantation
{
  int		nb_player;
  int		res[6];
}		t_incantation;

int		add_action(int, t_player *, char **, int);
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
void		send_expulse_to_graphic(t_kernel *, int);
void		send_elevation_to_graphic(t_kernel *, t_case *, t_player *);
void		send_finish_elevation_to_graphic(t_kernel *, t_case *,
    t_player *, int status);

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
t_bool		pnw(int, t_player *);
int		sbp(int);
int		print_mct(int, t_kernel *);
int		print_bct(int, t_case *, int, int);
int		print_players(int, t_kernel *);
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
int		incantation(char **av, t_client *, t_kernel *kernel);
int		cmd_fork(char **av, t_client *, t_kernel *kernel);
int		cmd_pond(char **av, t_client *, t_kernel *kernel);
int		cmd_connect_nbr(char **av, t_client *, t_kernel *kernel);

/*
** client utils functions.
*/
int		get_k_value(t_player *, t_player *, int, int);
int		ko(int fd);
t_bool		send_message(int, char *);

#endif /* !CLIENT_ACTION_H_ */
