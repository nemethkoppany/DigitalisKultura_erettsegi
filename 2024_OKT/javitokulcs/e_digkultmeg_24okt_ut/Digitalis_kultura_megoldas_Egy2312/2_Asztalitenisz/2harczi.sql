SELECT ev, versenyszam.nev
FROM versenyszam, jatekos, bajnok
WHERE jatekos.id = jatekos_id AND versenyszam.id = vsz_id AND
jatekos.nev="Harczi Zsolt";
