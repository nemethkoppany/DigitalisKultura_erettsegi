SELECT SUM(hirdetes.ar)*0.015
FROM hirdetes
WHERE hirdetes.allapot = "eladva" AND Year(hirdetes.datum) = 2021