SELECT telepules, Count(id) AS 'diákok száma'
FROM diakok
GROUP BY telepules
ORDER BY Count(id) DESC;
