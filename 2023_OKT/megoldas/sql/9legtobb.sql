SELECT diak.evfolyam, diak.betujel, COUNT(DISTINCT szakkor.azon) AS szakkorok_szama
FROM diak
INNER JOIN jelentkezes ON jelentkezes.diakazon = diak.azon
INNER JOIN szakkor ON szakkor.azon = jelentkezes.szakazon
GROUP BY diak.evfolyam, diak.betujel
ORDER BY szakkorok_szama DESC
LIMIT 1
