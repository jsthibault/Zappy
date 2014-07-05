/*
** get_player.c for get_player.c in /home/js/rendu/Zappy/src/server
**
** Made by thibau_j
** Login   <thibau_j@epitech.net>
**
** Started on  Wed Jul  2 23:06:47 2014 thibau_j
** Last update Sat Jul  5 15:26:46 2014 arnaud drain
*/

#include <stdlib.h>
#include "kernel.h"

t_player	*get_player_by_id(int id, t_list *players)
{
  t_node	*node;

  if (!players)
    return (NULL);
  node = players->head;
  while (node)
    {
      printf("id : %d\n", ((t_player *)node->data)->id);
      if (((t_player *)node->data)->id == id)
	{
	  return (node->data);
	}
      node = node->next;
    }
  return (NULL);
}
