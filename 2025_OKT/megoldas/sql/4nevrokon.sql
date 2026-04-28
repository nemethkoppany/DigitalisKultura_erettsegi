SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo
GROUP BY felhasznalo.veznev, felhasznalo.utonev
HAVING COUNT(felhasznalo.id) > 1
ORDER BY felhasznalo.veznev, felhasznalo.utonev