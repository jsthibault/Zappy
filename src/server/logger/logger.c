/*
** logger.c for server in /home/loic/dev/epitech/c/Zappy/src/server
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 16:16:56 2014 lefloc_l
** Last update sam. mai 17 14:18:29 2014 lefloc_l
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include "logger.h"

t_logger	*g_logger = NULL;

t_bool		logger_init(char *filename, t_bool verbose)
{
  logger_delete();
  g_logger = xmalloc(sizeof(t_logger));
  memset(g_logger, 0, sizeof(t_logger));
  if (!filename)
    filename = LOGGER_DEFAULT_FILENAME;
  strncpy(g_logger->filename, filename, LOGGER_FILENAME_SIZE);
  if (!(g_logger->file = fopen(g_logger->filename, LOGGER_FILE_RIGHTS)))
  {
    print_error();
    return (FALSE);
  }
  atexit(&logger_delete);
  g_logger->verbose = verbose;
  logger_message("{LOGGER} Starting");
  return (TRUE);
}

void		logger_delete()
{
  if (g_logger)
  {
    logger_message("{LOGGER} Delete");
    fclose(g_logger->file);
    free(g_logger);
    g_logger = NULL;
  }

}

