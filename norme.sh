#!/bin/bash

function norme_all
{
  ListeRep="$(find * -type d -prune)"   # liste des repertoires sans leurs sous-repertoires
  for Rep in ${ListeRep}; do
    cd ${Rep}
    norme_all
    echo ${Rep}
    ~/.scripts/norme.py *.c *.h
    cd ..
  done
}

norme_all
