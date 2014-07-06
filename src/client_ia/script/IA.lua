print "lancement de l'IA lua";

rotate = 1;
function seekItem(item, map)
   for key, value in pairs(map) do
      if key ~= 'n' and value == item then
	 rotate = 1;
	 return	goTo(key, item);
      end
   end
   if (rotate < 4) then
      rotate = rotate + 1;
      return ("droite")
   else
      rotate = 1;
   return "avance";
   end
end

function goTo(idMap, item)
   if idMap == 1 then
      return "prend "..item;
   elseif idMap == 3 or idMap == 7 or idMap == 13 or idMap == 21 or idMap == 31 or idMap == 43 or idMap == 57 or idMap == 73 then -- case devant
      return "avance";
   elseif idMap == 2 or idMap == 5 or idMap == 6 or (idMap >=10 and idMap <= 12) or (idMap >= 17 and idMap <= 20) or (idMap >= 26 and idMap <= 30) or (idMap >= 37 and idMap <= 42) or (idMap >= 50 and idMap <= 56) or (idMap >= 65 and idMap <= 72) then -- case a gauche
      print (idMap);
      return "gauche";
   else
      return "droite";
   end
end

function lvlUp(lvl, inv, map)   
   req = {{1, 0, 0, 0, 0, 0},
      {1, 1, 1, 0, 0, 0},
      {2, 0, 1, 0, 2, 0},
      {1, 1, 2, 0, 1, 0},
      {1, 2, 1, 3, 0, 0},
      {1, 2, 3, 0, 1, 0},
      {2, 2, 2, 2, 2, 1}};

   for i = 1,8 do
      if (inv[i] ~= req[i]) then
	 return seekItem(i, map);
      end
   end
end

function IA()
   
end