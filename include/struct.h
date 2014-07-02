/*
** struct.h for struct in /home/drain_a/rendu/Zappy
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Tue Jun 17 13:53:33 2014 arnaud drain
** Last update mer. juil. 02 22:26:58 2014 lefloc_l
*/

#ifndef STRUCT_H_
# define STRUCT_H_

# include "enum.h"
# include "list.h"
# include "buffer.h"

# define TEAM_NAME_SIZE		50
# define TEAM_MAX		100

/*
** Structure options, contains all command line options.
*/

typedef struct	s_options
{
  size_t	port;
  size_t	width;
  size_t	height;
  size_t	max_clients;
  size_t	delai;
  char		team_names[TEAM_MAX][TEAM_NAME_SIZE];
  size_t	nb_team_names;
}		t_options;

typedef struct	s_team
{
  t_list	*players;
  char		name[TEAM_NAME_SIZE];
}		t_team;

typedef struct	s_game
{
  struct s_list	*teams;
  struct s_list	*players;
  struct s_map	*map;
}		t_game;

typedef struct		s_kernel
{
  struct s_options	options;
  struct s_game		game;
  t_buffer		*buff_node;
  /*penser a rajouter le logger*/
}			t_kernel;

/*
** inventory. contain items. Each case = 1 item. (FOOD = items[0])
** The int on the case = number of this item
*/

typedef struct	s_inventory
{
  int		items[ITEM_TYPE];
}		t_inventory;

typedef struct		s_case
{
  struct s_inventory	inventory;
  t_list		*players;
}			t_case;

typedef struct	s_map
{
  int		width;
  int		height;
  t_case	**map;
}		t_map;

#endif /* !STRUCT_H_ */
