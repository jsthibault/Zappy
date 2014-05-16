##
## Makefile for  in /home/loic/dev/epitech/c/my_irc
##
## Made by loic lefloch
## Login   <lefloc_l@epitech.net>
##
## Started on  Sun Apr 27 11:04:42 2014 loic lefloch
## Last update  ven. mai 16 17:27:40 2014 lefloc_l
##

CC=	gcc

RM=	/bin/rm -rf

SERVER=		server

CLIENT=		client

DIR_SERVER=	src/server

DIR_CLIENT=	src/client

SRC_SERVER=	init_options.c \
		main.c \
		options_other.c \
		options_with_int.c \
		parse_options.c \
		utils.c \
		rock_on_map.c \
		food_on_map.c \
		get_on_map.c \
		init_map.c \
		client_action.c \
		logger_write.c \
		logger_print.c \
		logger.c \

SRC_CLIENT=

CFLAGS=		-Wall -Wextra -I./include/

OBJ_SERVER=	$(addprefix $(DIR_SERVER)/, $(SRC_SERVER:.c=.o))

OBJ_CLIENT=	$(addprefix $(DIR_CLIENT)/, $(SRC_CLIENT:.c=.o))

all:	$(SERVER)

$(SERVER):	$(OBJ_SERVER)
	$(CC) -o $(SERVER) $(OBJ_SERVER) $(CFLAGS)


$(CLIENT):	$(OBJ_CLIENT)
	$(CC) -o $(CLIENT) $(OBJ_CLIENT) $(CFLAGS)

clean:
	$(RM) $(OBJ_SERVER)
	$(RM) $(OBJ_CLIENT)


fclean:	clean
	$(RM) $(SERVER)
	$(RM) $(CLIENT)

re:	fclean all
