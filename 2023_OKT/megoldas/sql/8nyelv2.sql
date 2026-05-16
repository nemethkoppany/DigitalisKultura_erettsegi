SELECT szakkor.nev, szakkor.tanar, diak.nev, diak.evfolyam,diak.betujel
FROM szakkor
INNER JOIN jelentkezes ON jelentkezes.szakazon = szakkor.azon
INNER JOIN diak ON diak.azon = jelentkezes.diakazon
WHERE szakkor.mk = "2. idegen nyelv"
ORDER BY szakkor.nev, diak.nev