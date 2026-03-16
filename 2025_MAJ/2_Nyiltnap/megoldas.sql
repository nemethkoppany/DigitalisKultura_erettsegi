--2
SELECT diakok.nev
FROM diakok
WHERE diakok.telepules = "Barnamalom"

--3
SELECT orak.datum, orak.terem, orak.orasorszam
FROM orak
WHERE orak.targy = "angol"
ORDER BY orak.datum,orak.orasorszam

--4
SELECT orak.csoport, orak.targy, orak.datum
FROM orak
WHERE orak.csoport LIKE "9%" AND (orak.targy = "matematika" OR orak.targy = "fizika")
ORDER BY orak.targy

--5
SELECT diakok.telepules, COUNT(diakok.id)
FROM diakok
GROUP BY diakok.telepules
ORDER BY 2 DESC

--6
SELECT DISTINCT orak.targy
FROM orak
GROUP BY orak.targy

--7
SELECT diakok.nev, diakok.email, diakok.telefon
FROM diakok
INNER JOIN kapcsolo ON kapcsolo.diakid = diakok.id
INNER JOIN orak ON kapcsolo.oraid = orak.id
WHERE orak.tanar = "Angol Anna" AND orak.datum = "2028-11-10"

--8
SELECT diakok.nev
FROM diakok
WHERE diakok.telepules = (
	SELECT diakok.telepules
    FROM diakok
    WHERE diakok.nev = "Majer Melinda" 
)
AND diakok.nev != "Majer Melinda"

--9
SELECT orak.datum, orak.orasorszam, orak.targy, orak.tanar, orak.ferohely - COUNT(kapcsolo.diakid) AS szabad
FROM orak
INNER JOIN kapcsolo ON kapcsolo.oraid = orak.id
GROUP BY orak.id
HAVING szabad > 0
ORDER BY szabad DESC