/*
** options_with_int.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:13:13 2014 lefloc_l
** Last update mar. mai 13 16:21:10 2014 lefloc_l
*/

#include <stdlib.h>
#include "options.h"

t_bool	option_p(char **av, int ac, int *i, t_options *options)
{
  return (convert_to_int(av, ac, i, &options->port));
}

t_bool	option_x(char **av, int ac, int *i, t_options *options)
{
  return (convert_to_int(av, ac, i, &options->width));
}

t_bool	option_y(char **av, int ac, int *i, t_options *options)
{
  return (convert_to_int(av, ac, i, &options->height));
}

t_bool	option_c(char **av, int ac, int *i, t_options *options)
{
  return (convert_to_int(av, ac, i, &options->max_clients));
}

t_bool		option_t(char **av, int ac, int *i, t_options *options)
{
  return (convert_to_int(av, ac, i, &options->delai));
}
