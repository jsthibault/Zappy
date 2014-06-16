/*
** logger_print.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 16:29:32 2014 lefloc_l
** Last update Mon Jun 16 15:56:16 2014 arnaud drain
*/

#include <stdio.h>
#include <stdarg.h>
#include "logger.h"
#include "utils.h"

extern t_logger	*g_logger;

void		logger_message(char *msg, ...)
{
  va_list	av;

  va_start(av, msg);
  logger_write_on_file(LL_MESSAGE, msg, av);
  va_end(av);
}

void		logger_warning(char *msg, ...)
{
  va_list	av;

  va_start(av, msg);
  logger_write_on_file(LL_WARNING, msg, av);
  va_end(av);
}

void		logger_debug(char *msg, ...)
{
  va_list	av;

  va_start(av, msg);
  logger_write_on_file(LL_DEBUG, msg, av);
  va_end(av);
}

void		logger_error(char *msg, ...)
{
  va_list	av;

  va_start(av, msg);
  logger_write_on_file(LL_ERROR, msg, av);
  va_end(av);
}
