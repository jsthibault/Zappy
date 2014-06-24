/*
** logger_write.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 16:48:18 2014 lefloc_l
** Last update mer. juin 18 15:01:57 2014 lefloc_l
*/

#include <stdio.h>
#include <stdarg.h>
#include "logger.h"

extern t_logger	*g_logger;

static char	*logger_get_namelvl(t_log_level lvl)
{
  return (lvl == LL_MESSAGE ? "message" :
      (lvl == LL_WARNING ? "warning" :
       (lvl == LL_DEBUG ? "debug" :
        ( lvl == LL_ERROR ? "error" : "Invalid log level"))));
}

static char	*logger_get_colorlvl(t_log_level lvl)
{
  return (lvl == LL_MESSAGE ? COLOR_BLUE :
      (lvl == LL_WARNING ? COLOR_YELLOW :
       (lvl == LL_DEBUG ? COLOR_GREEN : COLOR_RED )));
}

void	logger_write_on_file(t_log_level lvl, char *msg, va_list av)
{
  char		buffer[LOGGER_BUFFER_SIZE];
  char		tmp[LOGGER_BUFFER_SIZE];
  va_list	cpy;

  snprintf(tmp, LOGGER_BUFFER_SIZE, "%s%s:%s %s", logger_get_colorlvl(lvl),
         logger_get_namelvl(lvl), COLOR_NORMAL, msg);
  vsnprintf(buffer, LOGGER_BUFFER_SIZE, tmp, av);
  //snprintf(tmp, LOGGER_BUFFER_SIZE, "%s: %s", logger_get_namelvl(lvl), msg);
  //vsnprintf(buffer, LOGGER_BUFFER_SIZE, tmp, av);
  fprintf(g_logger->file, "%s\n", buffer);
  if (g_logger->verbose == TRUE) {
   printf("%s\n", buffer);
  }
}


