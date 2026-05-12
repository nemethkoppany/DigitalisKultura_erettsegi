SELECT ingatlan.kozterulet, ingatlan.hazszam, elad.ar
FROM ingatlan, hirdetes AS megh, hirdetes AS elad
WHERE megh.ingatlanid = elad.ingatlanid
AND megh.ar = elad.ar
AND megh.allapot = "meghirdetve" 
AND elad.allapot = "eladva"
AND ingatlan.id = megh.ingatlanid
