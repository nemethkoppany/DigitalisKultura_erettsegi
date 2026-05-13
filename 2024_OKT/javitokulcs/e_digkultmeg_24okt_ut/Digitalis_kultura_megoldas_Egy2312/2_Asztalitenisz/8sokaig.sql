SELECT nev, max(ev)-min(ev)
FROM jatekos, bajnok
WHERE jatekos.id = jatekos_id
GROUP BY jatekos.id
HAVING max(ev)-min(ev)>=10
ORDER BY 2 DESC;
