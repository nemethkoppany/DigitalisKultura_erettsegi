SELECT COUNT(*), IF(neme=0,"nő","férfi")
FROM jatekos
GROUP BY jatekos.neme