##
## Makefile for  in /home/loic/dev/epitech/c/my_irc
##
## Made by loic lefloch
## Login   <lefloc_l@epitech.net>
##
## Started on  Sun Apr 27 11:04:42 2014 loic lefloch
## Last update Thu Jul 10 23:56:51 2014 arnaud drain
##

CC=	gcc

ECHO=	echo -e

RM=	/bin/rm -rf

SERVER=		server

CLIENT=		client

DIR_SERVER=	src/server
DIR_LIST=	src/list
DIR_CLIENT=	src/client_ia
DIR_BUFFER=	src/buffer

SRC_BUFFER=	buffer.c \
		concat_node.c \

SRC_SERVER=	options/init_options.c \
		server.c \
		my_str_to_wordtab.c \
		main.c \
		client.c \
		error.c \
		init.c \
		action.c \
		get_k_value.c \
		eggs.c \
		player/get_orientation.c \
		options/options_other.c \
		options/options_with_int.c \
		options/parse_options.c \
		utils.c \
		reseau/write_socket.c \
		reseau/write_all_graphic.c \
		reseau/send_message.c \
		map/dump_map.c \
		map/rock_on_map.c \
		map/food_on_map.c \
		map/get_on_map.c \
		map/init_map.c \
		map/delete_map.c \
		map/players_on_map.c \
		logger/logger_write.c \
		logger/logger_print.c \
		logger/logger.c \
		cmd/avance.c \
		cmd/droite.c \
		cmd/gauche.c \
		cmd/voir.c \
		cmd/voir2.c \
		cmd/inventaire.c \
		cmd/prend_objet.c \
		cmd/pose_objet.c \
		cmd/expulse.c \
		cmd/broadcast_texte.c \
		cmd/incantation.c \
		cmd/victory.c \
		cmd/fork.c \
		cmd/connect_nbr.c \
		kernel/init_kernel.c \
		kernel/delete_kernel.c \
		game/team.c \
		game/team_delete.c \
		game/game.c \
		game/player.c \
		game/player_team.c \
		player/init_player.c \
		player/remove_player.c \
		player/get_player.c \
		event/action.c \
		event/connexion.c \
		event/expulse.c \
		event/pose_prend.c \
		graphic_actions/bct.c \
		graphic_actions/ebo.c \
		graphic_actions/edi.c \
		graphic_actions/eht.c \
		graphic_actions/enw.c \
		graphic_actions/graphic.c \
		graphic_actions/ko.c \
		graphic_actions/mct.c \
		graphic_actions/msz.c \
		graphic_actions/pdi.c \
		graphic_actions/pdr.c \
		graphic_actions/pex.c \
		graphic_actions/pfk.c \
		graphic_actions/pgt.c \
		graphic_actions/pie.c \
		graphic_actions/pnw.c \
		graphic_actions/print_players.c \
		graphic_actions/sbp.c \
		graphic_actions/seg.c \
		graphic_actions/smg.c \
		graphic_actions/tna.c \
		graphic_actions/ppo.c \
		graphic_actions/plv.c \
		graphic_actions/sgt.c \
		graphic_actions/sst.c \
		graphic_actions/pin.c \

SRC_LIST=	list_add.c \
		list.c \
		list_get.c \
		list_loop.c \
		list_pop.c \
		list_perf.c \
		node.c

DIR_OBJ_SERVER=	obj/server/
DIR_OBJ_LIST=	obj/list/
DIR_OBJ_BUFFER=	obj/buffer/
DIR_OBJ_CLIENT=	obj/client_ia/

SRC_CLIENT=	main.c \
		option.c \
		func_option.c \
		init_reseau.c \
		handleIA.c

CFLAGS=		-W -Wall -Wextra -I./include/ -L./lib/ -pedantic
CDEBUG=		-O2 -g -ggdb

OBJ_SERVER=	$(addprefix $(DIR_OBJ_SERVER)/, $(SRC_SERVER:.c=.o))
OBJ_LIST=	$(addprefix $(DIR_OBJ_LIST)/, $(SRC_LIST:.c=.o))
OBJ_CLIENT=	$(addprefix $(DIR_OBJ_CLIENT)/, $(SRC_CLIENT:.c=.o))
OBJ_BUFFER=	$(addprefix $(DIR_OBJ_BUFFER)/, $(SRC_BUFFER:.c=.o))

LIB+=		-lefence

LDFLAGS+=	$(LIBPATH) $(LIB)

all:	$(SERVER) $(CLIENT)

$(SERVER):	$(OBJ_SERVER) $(OBJ_LIST) $(OBJ_BUFFER)
	@$(CC) -o $(SERVER) $(OBJ_SERVER) $(OBJ_LIST) $(OBJ_BUFFER) $(CFLAGS) $(CDEBUG) $(LDFLAGS)
	@$(ECHO) '\033[0;32m> Compiled\033[0m'

$(CLIENT):	$(OBJ_CLIENT)
	$(CC) -o $(CLIENT) $(OBJ_CLIENT) $(CFLAGS) $(LDFLAGS) -llua -lm -ldl

$(DIR_OBJ_SERVER)/%.o: $(DIR_SERVER)/%.c
	@mkdir -p $(@D)
	@$(CC) -o $@ -c $< $(CFLAGS)

$(DIR_OBJ_LIST)/%.o: $(DIR_LIST)/%.c
	@mkdir -p $(@D)
	@$(CC) -o $@ -c $< $(CFLAGS)

$(DIR_OBJ_CLIENT)/%.o: $(DIR_CLIENT)/%.c
	@mkdir -p $(@D)
	@$(CC) -o $@ -c $< $(CFLAGS)

$(DIR_OBJ_BUFFER)/%.o: $(DIR_BUFFER)/%.c
	@mkdir -p $(@D)
	@$(CC) -o $@ -c $< $(CFLAGS)

clean:
	@$(RM) $(OBJ_SERVER) $(OBJ_CLIENT) $(OBJ_LIST)
	@$(ECHO) '\033[0;31m> Directory cleaned\033[0m'

fclean:	clean
	$(RM) $(SERVER)
	$(RM) $(CLIENT)
	@$(ECHO) '\033[0;31m> Remove executable\033[0m'

re:	fclean all
