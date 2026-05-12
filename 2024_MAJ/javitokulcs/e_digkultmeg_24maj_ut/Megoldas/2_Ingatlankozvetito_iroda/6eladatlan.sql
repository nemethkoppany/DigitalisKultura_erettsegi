SELECT kozterulet, hazszam, datum
FROM ingatlan, hirdetes
WHERE ingatlan.id=ingatlanid
GROUP BY ingatlan.id
HAVING Count(hirdetes.id)=1
ORDER BY datum
LIMIT 1;