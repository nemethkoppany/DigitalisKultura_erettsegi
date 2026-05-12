SELECT kozterulet, hazszam, hirdet.ar
FROM ingatlan, hirdetes AS hirdet, hirdetes AS elad
WHERE ingatlan.id=hirdet.ingatlanid
	AND hirdet.ingatlanid=elad.ingatlanid
	AND hirdet.allapot='meghirdetve'
	AND elad.allapot='eladva'
	AND elad.ar=hirdet.ar;