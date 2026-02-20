--2
SELECT DISTINCT ingatlan.kozterulet
FROM ingatlan
WHERE ingatlan.lakas
ORDER BY ingatlan.kozterulet

--3
SELECT ingatlan.hazszam, hirdetes.ar
FROM ingatlan
JOIN hirdetes ON hirdetes.ingatlanid = ingatlan.id
WHERE ingatlan.kozterulet = "Agyagos utca" AND hirdetes.allapot = "meghirdetve"

--4
SELECT SUM(hirdetes.ar*0.015)
FROM hirdetes
WHERE hirdetes.allapot = "eladva" AND YEAR(hirdetes.datum) = 2021

--5
SELECT MAX(hirdetes.ar)/MIN(hirdetes.ar)
FROM hirdetes
WHERE hirdetes.allapot = "meghirdetve"

--6
SELECT ingatlan.kozterulet, ingatlan.hazszam, hirdetes.datum
FROM ingatlan
JOIN hirdetes ON hirdetes.ingatlanid = ingatlan.id
GROUP BY ingatlan.id
HAVING COUNT(hirdetes.id) = 1
ORDER BY hirdetes.datum
LIMIT 1;

--8
SELECT kozterulet, hazszam
FROM ingatlan
WHERE id NOT IN (
SELECT ingatlanid
FROM helyiseg
WHERE funkcio = "konyha")
	AND id NOT IN (
    SELECT ingatlanid
    FROM helyiseg
    WHERE funkcio = "WC");


--9
SELECT ingatlan.hazszam, ingatlan.kozterulet, SUM(helyiseg.hossz*helyiseg.szel*IF(funkcio = "terasz",0.5,1)) AS terulet
FROM ingatlan
JOIN helyiseg ON ingatlan.id = helyiseg.ingatlanid
GROUP BY ingatlan.id
HAVING terulet > 180