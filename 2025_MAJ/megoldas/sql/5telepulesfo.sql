SELECT COUNT(diakok.id), diakok.telepules
FROM diakok
GROUP BY diakok.telepules
ORDER BY COUNT(diakok.id) DESC