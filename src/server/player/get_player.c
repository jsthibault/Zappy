/*
** get_player.c for get_player.c in /home/js/rendu/Zappy/src/server
**
** Made by thibau_j
** Login   <thibau_j@epitech.net>
**
** Started on  Wed Jul  2 23:06:47 2014 thibau_j
** Last update Thu Jul  3 23:21:42 2014 thibau_j
*/

#include <stdlib.h>
#include "kernel.h"

t_player	*get_player_by_id(int id, t_list *players)
{
  t_node	*node;

  if (players == NULL)
    return (NULL);
  node = players->head;
  while (node)
    {
      if (((t_player *)node->data)->id == id)
	{
	  return (node->data);
	}
      node = node->next;
    }
  return (NULL);
}
