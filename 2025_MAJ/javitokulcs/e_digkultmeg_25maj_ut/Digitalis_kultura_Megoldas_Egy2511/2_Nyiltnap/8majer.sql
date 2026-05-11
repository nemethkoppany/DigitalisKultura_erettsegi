SELECT nev
FROM diakok
WHERE nev<>'Majer Melinda' AND telepules=(SELECT telepules FROM diakok WHERE nev='Majer Melinda');
