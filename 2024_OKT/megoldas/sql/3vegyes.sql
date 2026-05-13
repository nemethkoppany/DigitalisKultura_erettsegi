SELECT bajnok.ev
FROM bajnok
INNER JOIN versenyszam ON versenyszam.id = bajnok.vsz_id
WHERE versenyszam.nev = "vegyes páros"
ORDER BY bajnok.ev
LIMIT 1