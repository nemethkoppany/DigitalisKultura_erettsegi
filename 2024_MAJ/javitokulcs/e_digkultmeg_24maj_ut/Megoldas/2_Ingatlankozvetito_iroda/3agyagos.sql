SELECT hazszam, ar
FROM ingatlan, hirdetes
WHERE ingatlan.id=ingatlanid
	AND allapot='meghirdetve'
	AND kozterulet='Agyagos utca';