Zappy
=====

Oeuf - reproduction
-

Un joueur peut se reproduire grâce à la commande fork. L’exécution de cette com-
mande entraîne la production d’un oeuf. Dès la ponte le joueur l’ayant pondu peut vaquer
à ses occupations en attendant qu’il éclose. Lors de l’éclosion de l’oeuf, un nouveau joueur
en sort, il est orienté au hasard. Cette opération autorise la connexion d’un nouveau client.
La commande connect_nbr renvoie le nombre de connexions en cours et autorisées pour
cette famille.
Délai de ponte : 42 / t
Délai entre la ponte et l’éclosion : 600 / t

Pourquoi "bind: adress already in use" après avoir tout close ? oO

vérifier tout les free / close in game

vérifier tout les appels system (ainsi que les fonctions en héritant)

vérifier la norme

virer les todo et fence

y x ou x y partout :)
il faut faire un choix cornelien. choisi le bon cote de la force.

changer le depot

checker tout les header

====
retour en cascade:

  list_push_front / list_push_back



  verif les retour de write_socket ?


  verif retour en cascade des functions cmd_avance / cmd_expulse etc dans server.c


  DONE
 ===
  add_player_to_team
  init_player_with_teamname
 init_team
list_add_node
  add_player_on_map
  list_create
 move_player_on_map
  add_action -> check FALSE et plus -1

