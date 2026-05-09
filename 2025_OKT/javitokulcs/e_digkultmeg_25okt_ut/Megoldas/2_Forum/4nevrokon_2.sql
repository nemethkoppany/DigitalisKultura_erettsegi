SELECT DISTINCT f1.veznev, f1.utonev
FROM felhasznalo AS f1, felhasznalo AS f2
WHERE f1.veznev=f2.veznev AND f1.utonev=f2.utonev AND f1.id<>f2.id
ORDER BY f1.veznev, f1.utonev;