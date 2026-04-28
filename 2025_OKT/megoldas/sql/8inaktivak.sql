SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo
WHERE felhasznalo.utolso < "2010-01-01" 
AND felhasznalo.id NOT IN (SELECT uzenet.f_id FROM uzenet)