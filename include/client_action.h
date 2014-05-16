/*
** client_action.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 14:27:40 2014 lefloc_l
** Last update ven. mai 16 15:32:46 2014 lefloc_l
*/

#ifndef CLIENT_ACTION_H_
# define CLIENT_ACTION_H_

typedef struct	e_tab_func
{
  char		*command;
  char		*(*p)();
}		t_tab_func;

char		*cmd_avance();
char		*cmd_droite();
char		*cmd_gauche();
char		*cmd_voir();
char		*cmd_inventaire();
char		*cmd_prend_objet();
char		*cmd_pose_objet();
char		*cmd_expulse();
char		*cmd_broadcast_texte();
char		*cmd_incantation();
char		*cmd_fork();
char		*cmd_connect_nbr();

#endif /* !CLIENT_ACTION_H_ */
