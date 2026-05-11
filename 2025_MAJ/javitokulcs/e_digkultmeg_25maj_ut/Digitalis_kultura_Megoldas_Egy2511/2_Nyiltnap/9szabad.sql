SELECT datum, orasorszam, targy, tanar, 
	ferohely-Count(orak.id) AS szabad
FROM orak, kapcsolo
WHERE oraid=orak.id
GROUP BY orak.id
HAVING szabad>0
ORDER BY szabad DESC;
