/*
** logger.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  ven. mai 16 16:17:02 2014 lefloc_l
** Last update ven. mai 16 16:48:36 2014 lefloc_l
*/

#ifndef LOGGER_H_
# define LOGGER_H_

# include "utils.h"

# define LOGGER_FILENAME_SIZE		100
# define LOGGER_DEFAULT_FILENAME	"default.log"
# define LOGGER_FILE_RIGHTS		"a+"
# define LOGGER_BUFFER_SIZE		1000

typedef enum	e_log_level
{
  LL_MESSAGE,
  LL_DEBUG,
  LL_WARNING,
  LL_ERROR,
}		t_log_level;

typedef struct	s_logger
{
  char		filename[LOGGER_FILENAME_SIZE + 1];
  FILE		*file;
  t_bool	verbose;
}		t_logger;

t_bool		logger_init(char *filename, t_bool verbose);
void		logger_delete();
void		logger_message(char *msg, ...);
void		logger_warning(char *msg, ...);
void		logger_debug(char *msg, ...);
void		logger_error(char *msg, ...);

void	logger_write_on_file(t_log_level lvl, char *msg, va_list av);

#endif /* !LOGGER_H_ */