SELECT Min(ev) AS Első_vegyes_páros
FROM versenyszam, bajnok
WHERE versenyszam.id = vsz_id And nev="vegyes páros";