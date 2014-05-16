/*
** client_action.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:27:40 2014 lefloc_l
** Last update ven. mai 16 17:44:45 2014 lefloc_l
*/

#ifndef CLIENT_ACTION_H_
# define CLIENT_ACTION_H_

typedef struct	e_tab_func
{
  char		*command;
  void		*(*p)(char **res);
}		t_tab_func;

void		cmd_avance(char **res);
void		cmd_droite(char **res);
void		cmd_gauche(char **res);
void		cmd_voir(char **res);
void		cmd_inventaire(char **res);
void		cmd_prend_objet(char **res);
void		cmd_pose_objet(char **res);
void		cmd_expulse(char **res);
void		cmd_broadcast_texte(char **res);
void		cmd_incantation(char **res);
void		cmd_fork(char **res);
void		cmd_connect_nbr(char **res);

#endif /* !CLIENT_ACTION_H_ */
