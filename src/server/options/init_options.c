/*
** init_options.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 16:07:52 2014 lefloc_l
** Last update mar. mai 13 16:09:35 2014 lefloc_l
*/

#include "options.h"

void	init_options(t_options *options)
{
  options->port = DEFAULT_PORT;
  options->width = DEFAULT_WIDTH;
  options->height = DEFAULT_HEIGHT;
  options->max_clients = DEFAULT_MAX_CLIENTS;
  options->delai = DEFAULT_DELAI;
}
