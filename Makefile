##
## Makefile for  in /home/loic/dev/epitech/c/my_irc
##
## Made by loic lefloch
## Login   <lefloc_l@epitech.net>
##
## Started on  Sun Apr 27 11:04:42 2014 loic lefloch
## Last update  sam. mai 17 19:03:20 2014 lefloc_l
##

CC=	gcc

ECHO=	echo -e

RM=	/bin/rm -rf

SERVER=		server

CLIENT=		client

DIR_SERVER=	src/server
DIR_LIST=	src/list
DIR_CLIENT=	src/client

SRC_SERVER=	options/init_options.c \
		main.c \
		options/options_other.c \
		options/options_with_int.c \
		options/parse_options.c \
		utils.c \
		map/rock_on_map.c \
		map/food_on_map.c \
		map/get_on_map.c \
		map/init_map.c \
		map/delete_map.c \
		client_action.c \
		logger/logger_write.c \
		logger/logger_print.c \
		logger/logger.c \
		cmd/avance.c \
		cmd/droite.c \
		cmd/gauche.c \
		cmd/voir.c \
		cmd/inventaire.c \
		cmd/prend_objet.c \
		cmd/pose_objet.c \
		cmd/expulse.c \
		cmd/broadcast_texte.c \
		cmd/incantation.c \
		cmd/fork.c \
		cmd/connect_nbr.c \
		kernel/init_kernel.c \
		kernel/run_kernel.c \
		kernel/signal.c \
		kernel/delete_kernel.c \
		game/team.c \
		game/team_delete.c \
		game/game.c \
		game/player.c \
		game/player_team.c \

SRC_LIST=	list_add.c \
		list.c \
		list_get.c \
		list_loop.c \
		list_pop.c \
		node.c \

SRC_CLIENT=

CFLAGS=		-W -Wall -Wextra -I./include/ -pedantic
CDEBUG=		-O2 -g -ggdb

OBJ_SERVER=	$(addprefix $(DIR_SERVER)/, $(SRC_SERVER:.c=.o))
OBJ_LIST=	$(addprefix $(DIR_LIST)/, $(SRC_LIST:.c=.o))
OBJ_CLIENT=	$(addprefix $(DIR_CLIENT)/, $(SRC_CLIENT:.c=.o))

all:	$(SERVER)

$(SERVER):	$(OBJ_SERVER) $(OBJ_LIST)
	$(CC) -o $(SERVER) $(OBJ_SERVER) $(OBJ_LIST) $(CFLAGS) $(CDEBUG)
	@$(ECHO) '\033[0;32m> Compiled\033[0m'

$(CLIENT):	$(OBJ_CLIENT)
	$(CC) -o $(CLIENT) $(OBJ_CLIENT) $(CFLAGS)

clean:
	$(RM) $(OBJ_SERVER)
	$(RM) $(OBJ_CLIENT)
	@$(ECHO) '\033[0;31m> Directory cleaned\033[0m'


fclean:	clean
	$(RM) $(SERVER)
	$(RM) $(CLIENT)
	@$(ECHO) '\033[0;31m> Remove executable\033[0m'

re:	fclean all

