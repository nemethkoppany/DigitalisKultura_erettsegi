SELECT szakkor.nev, szakkor.tanar, szakkor.mk, COUNT(jelentkezes.diakazon)
FROM szakkor
INNER JOIN jelentkezes ON jelentkezes.szakazon = szakkor.azon
GROUP BY szakkor.nev
HAVING COUNT(jelentkezes.diakazon) >= 10 
