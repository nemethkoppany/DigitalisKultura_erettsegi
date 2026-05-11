SELECT diakok.nev
FROM diakok
WHERE 
diakok.telepules = (

SELECT diakok.telepules
FROM diakok
WHERE diakok.nev = "Majer Melinda"
)
AND diakok.nev <> "Majer Melinda"