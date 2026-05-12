SELECT ingatlan.kozterulet, ingatlan.hazszam,SUM(IF(helyiseg.funkcio = "terasz",hossz*szel*0.5, hossz * szel))AS osszterulet
FROM ingatlan
INNER JOIN helyiseg ON ingatlan.id 	= helyiseg.ingatlanid
GROUP BY ingatlan.id
HAVING osszterulet >180