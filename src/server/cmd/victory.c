/*
** victory.c for victory in /home/drain_a/rendu/Zappy
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Wed Jul  9 20:15:55 2014 arnaud drain
** Last update Wed Jul  9 20:22:11 2014 arnaud drain
*/

#include "game.h"
#include "server.h"
#include "struct.h"

int		check_team_victory(t_team *team)
{
  t_node	*node;
  int		required;

  if (!(team->players))
    return (0);
  required = PLAYER_REQUIRED;
  node = team->players->head;
  while (node)
    {
      if (((t_player *)node->data)->level == END_LVL)
	--required;
      node = node->next;
    }
  if (required <= 0)
    return (1);
  return (0);
}

int		check_victory(t_kernel *kernel)
{
  char		buffer[BUFFER_SIZE];
  t_node	*node;

  node = kernel->game.teams->head;
  while (node)
    {
      if (check_team_victory(node->data))
	{
	  sprintf(buffer, "seg %s\n", ((t_team *)node->data)->name);
	  write_all_graphic(kernel, buffer);
	  return (-1);
	}
      node = node->next;
    }
  return (0);
}
