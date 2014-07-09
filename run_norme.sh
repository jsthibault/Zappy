#!/bin/bash

./norme.sh | grep -v "lua" | grep -v "lauxlib" | grep Erreur
