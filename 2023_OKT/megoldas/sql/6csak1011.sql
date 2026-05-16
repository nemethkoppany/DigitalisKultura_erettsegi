SELECT DISTINCT szakkor.nev
FROM szakkor
INNER JOIN jelentkezes ON jelentkezes.szakazon = szakkor.azon
INNER JOIN diak ON diak.azon = jelentkezes.diakazon
WHERE diak.evfolyam = 10 OR diak.evfolyam = 11 AND szakkor.azon NOT IN (
	SELECT jelentkezes.szakazon
		FROM jelentkezes
		INNER JOIN diak ON diak.azon = jelentkezes.diakazon
		WHERE diak.evfolyam != 10 AND diak.evfolyam != 11
)