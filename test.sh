#!/bin/bash

{
echo "dewd"
sleep 1
i=5000
while [ "$i" -gt 1 ]
do
    echo -n "trolooooololo"
done
echo ""
sleep 2
} | telnet $1 $2
