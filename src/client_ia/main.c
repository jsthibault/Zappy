/*
** main.c for client_ia in /home/drain_a/rendu/Zappy/src/client_ia
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sat Jul  5 14:59:20 2014 arnaud drain
** Last update Sat Jul  5 15:08:13 2014 arnaud drain
*/

#include <sys/select.h>
#include <sys/time.h>
#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
#include <arpa/inet.h>
#include <netdb.h>

#define BUFFER_SIZE 4096

static int	return_error(char *str, int option)
{
  if (option)
    perror(str);
  else
    fprintf(stderr, str);
  return (-1);
}

static int	read_server(int sfd)
{
  char		buffer[BUFFER_SIZE] = {0};

  if (read(sfd, &buffer, sizeof(buffer)) <= 0)
    return (-1);
  printf("%s", buffer);
  return (0);
}

static int	post_select(fd_set *fd_in, int sfd)
{
  if (FD_ISSET(sfd, fd_in))
    {
      if (read_server(sfd))
	{
	  close(sfd);
	  printf("connection with the server lost\n");
	}
    }
  return (0);
}

static int		init(char *machine, int port)
{
  int			sfd;
  struct sockaddr_in	sin;
  struct protoent	*pe;

  if (!(pe = getprotobyname("TCP")))
    return (return_error("getprotobyname", 1));
  if ((sfd = socket(AF_INET, SOCK_STREAM, pe->p_proto)) < 0)
    return (return_error("sfd", 1));
  sin.sin_family = AF_INET;
  sin.sin_port = htons(port);
  if (!(sin.sin_addr.s_addr = inet_addr(machine)))
    return (return_error("Adresse incorrecte\n", 0));
  if (connect(sfd, (struct sockaddr *)&sin, sizeof(sin)) == -1)
    {
      close(sfd);
      return (return_error("connect", 1));
    }
  return (sfd);
}

int	main()
{
  fd_set	fd_in;
  int		sfd;

  if ((sfd = init("127.0.0.1", 4242)) < 0)
    return (-1);
  while (1)
    {
      FD_ZERO(&fd_in);
      FD_SET(sfd, &fd_in);
      if (select(sfd + 1, &fd_in, NULL, NULL, NULL) == -1)
	{
	  close(sfd);
	  return (-1);
	}
      if (post_select(&fd_in, sfd))
	return (1);
    }
  return (0);
}
