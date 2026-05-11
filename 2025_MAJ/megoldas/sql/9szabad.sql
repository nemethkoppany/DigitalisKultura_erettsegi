SELECT orak.datum, orak.orasorszam, orak.targy, orak.tanar, orak.ferohely - COUNT(kapcsolo.diakid) AS szabad
FROM orak
INNER JOIN kapcsolo ON orak.id = kapcsolo.oraid
GROUP BY orak.id
HAVING szabad > 0
ORDER BY szabad DESC