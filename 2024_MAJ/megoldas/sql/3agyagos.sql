SELECT ingatlan.hazszam, hirdetes.ar
FROM ingatlan
INNER JOIN hirdetes ON ingatlan.id = hirdetes.ingatlanid
WHERE hirdetes.allapot ="meghirdetve" AND ingatlan.kozterulet = "Agyagos utca"