SELECT kozterulet, hazszam, SUM(hossz*szel*IF(funkcio="terasz",0.5,1)) AS terulet
FROM ingatlan, helyiseg
WHERE ingatlan.id=ingatlanid
GROUP BY ingatlan.id
HAVING terulet>180;