SELECT DISTINCT diak.evfolyam, diak.betujel
FROM diak
INNER JOIN jelentkezes ON jelentkezes.diakazon = diak.azon
INNER JOIN szakkor ON jelentkezes.szakazon = szakkor.azon
WHERE szakkor.mk = "Matematika"
ORDER BY diak.evfolyam,diak.betujel