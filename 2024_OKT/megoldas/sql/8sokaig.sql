SELECT jatekos.nev, utolso.ev - elso.ev AS idotav 
FROM jatekos, bajnok AS elso, bajnok AS utolso 
WHERE jatekos.id = elso.jatekos_id 
AND (utolso.ev - elso.ev) >= 10 
ORDER BY "idotav" DESC

--VAGY

SELECT nev, Max(ev)-Min(ev) AS idotav
FROM jatekos, bajnok
WHERE jatekos.id = jatekos_id
GROUP BY jatekos.id
HAVING idotav>=10
ORDER BY idotav DESC;