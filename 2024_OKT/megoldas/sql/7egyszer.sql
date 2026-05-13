SELECT jatekos.nev, bajnok.ev, versenyszam.nev
FROM jatekos
INNER JOIN bajnok ON bajnok.jatekos_id = jatekos.id
INNER JOIN versenyszam ON bajnok.vsz_id = versenyszam.id
WHERE jatekos.id IN (
	SELECT bajnok.jatekos_id
    FROM bajnok
    GROUP BY bajnok.jatekos_id
    HAVING COUNT(jatekos.id = 1)
)

--VAGY

SELECT jatekos.nev, ev, versenyszam.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id = jatekos_id AND versenyszam.id = vsz_id
GROUP BY jatekos_id
HAVING Count(jatekos_id)=1;