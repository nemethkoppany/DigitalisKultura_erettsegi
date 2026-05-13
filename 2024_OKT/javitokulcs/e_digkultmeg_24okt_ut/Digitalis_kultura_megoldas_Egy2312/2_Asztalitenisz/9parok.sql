SELECT DISTINCT jatekos.nev
FROM jatekos, bajnok, versenyszam
WHERE jatekos.id = jatekos_id AND vsz_id = versenyszam.id AND
      jatekos.nev<>'Pergel Szandra' AND versenyszam.nev='vegyes páros' AND
      ev IN (SELECT ev
             FROM jatekos, bajnok, versenyszam
             WHERE jatekos.id = jatekos_id AND vsz_id = versenyszam.id AND
                   versenyszam.nev='vegyes páros' AND jatekos.nev = 'Pergel Szandra' );
