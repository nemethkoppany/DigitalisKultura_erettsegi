SELECT veznev, utonev
FROM felhasznalo
WHERE utolso<'2010-01-01' AND
	id NOT IN (SELECT f_id FROM uzenet);