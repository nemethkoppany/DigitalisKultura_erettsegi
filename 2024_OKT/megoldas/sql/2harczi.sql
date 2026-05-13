SELECT versenyszam.nev, bajnok.ev
FROM versenyszam
INNER JOIN bajnok ON bajnok.vsz_id = versenyszam.id
INNER JOIN jatekos ON jatekos.id = bajnok.jatekos_id
WHERE jatekos.nev = "Harczi Zsolt"