SELECT kozterulet, hazszam
FROM ingatlan
WHERE id NOT IN (SELECT helyiseg.ingatlanid
                FROM helyiseg
                WHERE helyiseg.funkcio = "konyha")
	AND id NOT IN (SELECT helyiseg.ingatlanid
    FROM helyiseg
    WHERE helyiseg.funkcio = "WC");
