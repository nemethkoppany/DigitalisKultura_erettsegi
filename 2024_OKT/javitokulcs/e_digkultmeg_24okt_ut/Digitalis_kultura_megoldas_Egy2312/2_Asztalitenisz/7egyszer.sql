SELECT jatekos.nev, ev, versenyszam.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id = jatekos_id AND versenyszam.id = vsz_id AND
      jatekos_id in (SELECT jatekos_id
                     FROM bajnok
                     GROUP BY jatekos_id
                     HAVING Count(id)=1);
