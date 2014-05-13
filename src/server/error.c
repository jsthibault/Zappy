/*
** error.c for error in /home/drain_a/rendu/PSU_2013_myftp
** 
** Made by arnaud drain
** Login   <drain_a@epitech.net>
** 
** Started on  Sun Apr 13 12:53:21 2014 arnaud drain
** Last update Sun Apr 13 12:54:36 2014 arnaud drain
*/

#include <stdio.h>

int	return_error(char *str, int option)
{
  if (option)
    perror(str);
  else
    fprintf(stderr, str);
  return (-1);
}
