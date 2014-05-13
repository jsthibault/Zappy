/*
** main.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:36:26 2014 lefloc_l
** Last update mar. mai 13 16:24:42 2014 lefloc_l
*/

#include "options.h"

int		main(int argc, const char *argv[])
{
  t_options	options;

  init_options(&options);
  if (!parse_options(argc, argv, &options))
    fprintf(stderr, "Usage\n");
  dump_options(&options);
  return 0;
}
