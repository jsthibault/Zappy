/*
** functions.c for functions in /home/drain_a/rendu/PSU_2013_myirc
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sat Apr 19 14:20:12 2014 arnaud drain
** Last update Tue May 13 19:41:07 2014 arnaud drain
*/

#include <string.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include "server.h"

int	graphic(char **av, t_client *cl)
{
  (void)av;
  write_socket(cl->fd, "BIENVENUE\n");
  return (0);
}
