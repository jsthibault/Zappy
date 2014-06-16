/*
** init_options.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 16:07:52 2014 lefloc_l
** Last update Mon Jun 16 16:10:49 2014 arnaud drain
*/

#include "options.h"

void	init_options(t_options *options)
{
  options->port = DEFAULT_PORT;
  options->width = DEFAULT_WIDTH;
  options->height = DEFAULT_HEIGHT;
  options->max_clients = DEFAULT_MAX_CLIENTS;
  options->delai = DEFAULT_DELAI;
  options->nb_team_names = 0;
}
