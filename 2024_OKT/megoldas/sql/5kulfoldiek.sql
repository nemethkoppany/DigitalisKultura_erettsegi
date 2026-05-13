SELECT DISTINCT egyesulet.orszag
FROM egyesulet
INNER JOIN bajnok ON bajnok.egyesulet_id = egyesulet.id
WHERE bajnok.ev > 2000 AND egyesulet.orszag <> "Magyarország"