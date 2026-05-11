SELECT diakok.nev, diakok.email, diakok.telefon
FROM diakok

INNER JOIN kapcsolo ON diakok.id = kapcsolo.diakid
INNER JOIN orak ON orak.id = kapcsolo.oraid

WHERE orak.tanar = "Angol Anna" AND orak.datum = "2028.11.10"