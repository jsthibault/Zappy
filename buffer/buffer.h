/*
** buffer.h for buffer in /home/js/bufferisationNaxNax
**
** Made by thibau_j
** Login   <thibau_j@epitech.net>
**
** Started on  Sun May 25 17:49:03 2014 thibau_j
** Last update Tue May 27 09:45:47 2014 thibau_j
*/

#ifndef BUFFER_H_
# define BUFFER_H_

# define SIZE 5

typedef struct		s_buffer
{
  char			buff[SIZE + 1];
  int			full;
  struct s_buffer	*next;
}			t_buffer;

void			*my_error_ptr(char *error);
char			*concat_buff_node(t_buffer *ptr);
char			*read_on(int fd, t_buffer *ptr);

#endif /* !BUFFER_H_ */
