SELECT veznev, utonev
FROM felhasznalo
GROUP BY veznev, utonev
HAVING COUNT(*)>1
ORDER BY veznev, utonev;