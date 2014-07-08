/*
** expulse.c for event in /home/loic/dev/epitech/c/Zappy/src/server/event
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  lun. juil. 07 15:03:32 2014 lefloc_l
** Last update mar. juil. 08 15:24:13 2014 lefloc_l
*/

#include "kernel.h"
#include "client_action.h"

void	send_expulse_to_graphic(t_kernel *kernel, int player_id)
{
  char	buffer[BUFFER_SIZE];

  sprintf(buffer, "pex %d\n", player_id);
  write_all_graphic(kernel, buffer);
}
