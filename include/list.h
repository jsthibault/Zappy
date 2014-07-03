/*
** list.h for include in /home/loic/dev/epitech/c/Zappy/include
**
** Made by lefloc_l
** Login <lefloc_l@epitech.eu>
**
** Started on  sam. mai 17 15:47:09 2014 lefloc_l
** Last update Thu Jul  3 23:22:09 2014 thibau_j
*/

#ifndef LIST_H_
# define LIST_H_

# include "utils.h"

typedef struct	s_node
{
  void		*data;
  struct s_node	*next;
  struct s_node	*prev;
}		t_node;

typedef struct	s_list
{
  size_t	size;
  t_node	*head;
  t_node	*tail;
}		t_list;

/*
** functions pointers. name is ptr +
** first letter of return and arguments type
** b is for t_bool, n for t_node
*/

typedef void	(*ptrvv)(void *);
typedef t_bool	(*ptrbv)(void *);
typedef t_bool	(*ptrbvv)(void *, void *);
typedef void	(*ptrvnv)(t_list *, t_node *, void *);

void		list_add_node(t_list **list, t_node *node, void *data);
void		list_pop_node(t_list *list, t_node *node);

t_node		*list_create_node(void *data);

t_list		*list_create();
void		list_delete(t_list *list);
void		list_clear(t_list *list);

void		list_push_front(t_list **list, void *data);
void		list_push_back(t_list **list, void *data);

void		list_pop(t_list **list, void *data);
void		list_pop_front(t_list **list);
void		list_pop_back(t_list **list);
void		list_pop_func(t_list **list, ptrbv);
void		list_pop_func_arg(t_list **list, ptrbvv, void *arg);

void		*list_get_front(t_list *list);
void		*list_get_back(t_list *list);
void		*list_get_at(t_list *list, size_t pos);
void		*list_get_func(t_list *list, ptrbv func);
void		*list_get_func_arg(t_list *list, ptrbvv func, void *arg);

void		*list_recur_action(t_list *list, ptrvnv func, void *arg);

size_t		list_size(t_list *list);
t_bool		list_is_empty(t_list *list);

void		list_foreach(t_list *list, ptrvv func);

void		list_pop_verification(t_list **);

#endif /* !LIST_H_ */
