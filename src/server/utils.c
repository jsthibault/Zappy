/*
** utils.c for server in /home/loic/dev/epitech/c/Zappy/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  mar. mai 13 15:24:36 2014 lefloc_l
** Last update Wed Jul  9 01:36:12 2014 arnaud drain
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>
#include "utils.h"
#include "kernel.h"
#include "map.h"

int		av_length(char **av)
{
  int		i;

  i = 0;
  while (av[i])
    ++i;
  return (i);
}

t_bool		is_num(char *str)
{
  size_t	j;

  if (!str)
    return (FALSE);
  for (j = 0; str[j]; ++j)
  {
    if (str[j] < '0' || str[j] > '9')
    {
      fprintf(stderr, "%s is not a number\n", str);
      return (FALSE);
    }
  }
  return (TRUE);
}

t_bool		is_float(char *str)
{
  size_t	i;

  if (!str)
    return (FALSE);
  for (i = 0; str[i]; ++i)
  {
    if ((str[i] < '0' || str[i] > '9') && str[i] != '.')
    {
      fprintf(stderr, "%s is not a float number\n", str);
      return (FALSE);
    }
  }
  return (TRUE);
}

int		write_socket(int fd, char *str)
{
  /*fd_set	fd_out;
  fd_set	fd_in;
  int		ret;

  FD_ZERO(&fd_out);
  FD_SET(fd, &fd_out);
  FD_ZERO(&fd_in);
  FD_SET(fd, &fd_in);
  if (select(fd + 1, &fd_in, &fd_out, NULL, NULL) == -1)
    {
      printf("bye\n");
      exit(0);
    }
  printf("fd isset out : %d\n", FD_ISSET(fd, &fd_out));
  printf("fd isset in : %d\n", FD_ISSET(fd, &fd_in));
  //printf("read of 0 : %d\n", (int)read(fd, NULL, 0));
  printf("trying to write\n");
  ret = write(fd, str, strlen(str));
  printf("write return : %d\n", ret);
  return (ret);*/
  //TODO : ASK LAB ASTEK ABOUT SIGPIPE
  return (write(fd, str, strlen(str)));
}

void	*xmalloc(size_t size)
{
  void	*ptr;

  if (!(ptr = malloc(size)))
    return (NULL);
  return (ptr);
}

void	print_error(char *str)
{
  if (!str)
    str = strerror(errno);
  fprintf(stderr, "%sFatal error: %s%s\n", COLOR_RED, COLOR_NORMAL, str);
}
