SELECT szakkor.nev, diak.nev
FROM szakkor
INNER JOIN jelentkezes ON jelentkezes.szakazon = szakkor.azon
INNER JOIN diak ON diak.azon = jelentkezes.diakazon
WHERE diak.nev != "Beke Fanni" AND szakkor.nev IN
(
	SELECT szakkor.nev
    FROM szakkor
    INNER JOIN jelentkezes ON jelentkezes.szakazon = szakkor.azon
	INNER JOIN diak ON diak.azon = jelentkezes.diakazon
    WHERE diak.nev = "Beke Fanni"
)
AND diak.evfolyam = (
	SELECT diak.evfolyam
    FROM diak
    WHERE diak.nev = "Beke Fanni"
)

--VAGY

SELECT diak1.nev, szakkor.nev
FROM diak AS diak1, jelentkezes AS jelentkezes1,
szakkor, diak AS diak2, jelentkezes AS jelentkezes2
WHERE diak1.azon = jelentkezes1.diakazon
AND diak2.azon = jelentkezes2.diakazon
AND szakkor.azon = jelentkezes2.szakazon
AND diak2.evfolyam = diak1.evfolyam
AND jelentkezes1.szakazon = szakkor.azon
AND diak2.nev="Beke Fanni"
AND diak1.nev<>"Beke Fanni";