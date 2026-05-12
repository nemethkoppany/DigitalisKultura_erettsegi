SELECT ingatlan.kozterulet, ingatlan.hazszam, hirdetes.datum
FROM ingatlan
INNER JOIN hirdetes ON hirdetes.ingatlanid = ingatlan.id
GROUP BY hirdetes.ingatlanid
HAVING COUNT(hirdetes.ingatlanid) = 1
ORDER BY hirdetes.datum ASC 
LIMIT 1;