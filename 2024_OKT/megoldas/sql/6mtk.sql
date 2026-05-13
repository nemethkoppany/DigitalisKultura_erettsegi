SELECT DISTINCT jatekos.nev
FROM jatekos
INNER JOIN bajnok ON bajnok.jatekos_id = jatekos.id
INNER JOIN egyesulet ON bajnok.egyesulet_id = egyesulet.id
WHERE egyesulet.nev = "MTK"
GROUP BY jatekos.id
ORDER BY jatekos.neme, jatekos.nev