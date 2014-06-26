/*
** client_action.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:27:40 2014 lefloc_l
** Last update Thu Jun 26 16:20:48 2014 arnaud drain
*/

#ifndef CLIENT_ACTION_H_
# define CLIENT_ACTION_H_

#include "struct.h"
#include "server.h"

typedef struct	e_tab_func
{
  char		*command;
  int		(*p)(char **av, t_client *cl, t_kernel *kernel);
}		t_tab_func;

int		cmd_avance(char **av, t_client *cl, t_kernel *kernel);
int		cmd_droite(char **av, t_client *cl, t_kernel *kernel);
int		cmd_gauche(char **av, t_client *cl, t_kernel *kernel);
int		cmd_voir(char **av, t_client *cl, t_kernel *kernel);
int		cmd_inventaire(char **av, t_client *cl, t_kernel *kernel);
int		cmd_prend_objet(char **av, t_client *cl, t_kernel *kernel);
int		cmd_pose_objet(char **av, t_client *cl, t_kernel *kernel);
int		cmd_expulse(char **av, t_client *cl, t_kernel *kernel);
int		cmd_broadcast_texte(char **av, t_client *cl, t_kernel *kernel);
int		cmd_incantation(char **av, t_client *cl, t_kernel *kernel);
int		cmd_fork(char **av, t_client *cl, t_kernel *kernel);
int		cmd_connect_nbr(char **av, t_client *cl, t_kernel *kernel);

#endif /* !CLIENT_ACTION_H_ */
