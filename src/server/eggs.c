/*
** eggs.c for eggs in /home/drain_a/rendu/Zappy
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Thu Jul 10 23:21:32 2014 arnaud drain
** Last update Thu Jul 10 23:53:43 2014 arnaud drain
*/

#include <stdlib.h>
#include <stdio.h>
#include "struct.h"
#include "server.h"

static int	get_egg_max_id(t_list *eggs)
{
  int		max_id;
  t_egg		*egg;
  t_node	*node;

  max_id = 0;
  node = NULL;
  if (eggs)
    node = eggs->head;
  while (node)
    {
      egg = (t_egg *)node->data;
      if (egg->id > max_id)
	max_id = egg->id;
      node = node->next;
    }
  return (max_id);
}

int	add_egg(t_kernel *kernel, t_player *player)
{
  char	buffer[BUFFER_SIZE];
  t_egg	*egg;

  if (!(egg = malloc(sizeof(*egg))))
    return (-1);
  egg->id = get_egg_max_id(kernel->game.eggs);
  egg->player_id = player->id;
  egg->team = player->team;
  egg->pos.x = player->pos.x;
  egg->pos.y = player->pos.y;
  egg->time_left = 600;
  if (list_push_front(&(kernel->game.eggs), egg) == FALSE)
    return (-1);
  sprintf(buffer, "enw %d %d %d %d\n", egg->id, player->id, egg->pos.x, egg->pos.y);
  write_all_graphic(kernel, buffer);
  return (0);
}

void		print_all_eggs(t_kernel *kernel)
{
  char		buffer[BUFFER_SIZE];
  t_egg		*egg;
  t_node	*node;

  node = NULL;
  if (kernel->game.eggs)
    node = kernel->game.eggs->head;
  while (node)
    {
      egg = (t_egg *)node->data;
      sprintf(buffer, "enw %d %d %d %d\n", egg->id, egg->player_id, egg->pos.x, egg->pos.y);
      write_all_graphic(kernel, buffer);
      node = node->next;
    }
}
