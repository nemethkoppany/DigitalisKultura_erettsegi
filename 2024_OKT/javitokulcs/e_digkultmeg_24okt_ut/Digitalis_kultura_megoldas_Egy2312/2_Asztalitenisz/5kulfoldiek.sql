SELECT orszag
FROM egyesulet, bajnok
WHERE egyesulet.id = egyesulet_id AND ev>2000
GROUP BY egyesulet.orszag
HAVING orszag<>'Magyarország';
