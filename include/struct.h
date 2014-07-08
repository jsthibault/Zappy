/*
** struct.h for struct in /home/drain_a/rendu/Zappy
**
** Made by arnaud drain
** Login   <drain_a@epitech.net>
**
** Started on  Tue Jun 17 13:53:33 2014 arnaud drain
** Last update Tue Jul  8 00:46:42 2014 arnaud drain
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

/*
** inventory. contain items. Each case = 1 item. (FOOD = items[0])
** The int on the case = number of this item
*/

typedef struct	s_inventory
{
  int		items[ITEM_TYPE];
}		t_inventory;

typedef struct		s_player
{
  int			id;
  t_pos			pos;
  t_team		*team;
  int			pv;
  int			level;
  struct s_client	*client;
  int			food_time;
  t_orientation		orientation;
  t_inventory		inventory;
}			t_player;

typedef struct	s_game
{
  struct s_list	*teams;
  struct s_list	*players;
  struct s_map	*map;
}		t_game;

typedef struct s_client	t_client;

struct		s_client
{
  int		fd;
  char		*ip;
  t_bool	graphic;
  t_player	*player;
  t_client	*next;
};

typedef struct s_actions t_actions;

struct	s_actions
{
  int		time_left;
  char		**av;
  t_client	*client;
  t_actions	*next;
};

typedef struct		s_kernel
{
  struct s_options	options;
  struct s_game		game;
  struct s_actions	*actions;
  struct s_client	*clients;
  t_buffer		*buff_node;
  /*penser a rajouter le logger*/
}			t_kernel;

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
