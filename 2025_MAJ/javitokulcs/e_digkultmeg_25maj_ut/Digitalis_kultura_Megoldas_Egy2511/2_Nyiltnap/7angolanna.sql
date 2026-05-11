SELECT nev, email, telefon
FROM orak, diakok, kapcsolo
WHERE tanar='Angol Anna' AND datum='2028.11.10' AND diakok.id=diakid and orak.id=oraid;8
