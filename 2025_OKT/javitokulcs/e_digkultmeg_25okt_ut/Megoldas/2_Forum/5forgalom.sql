SELECT megnevezes, COUNT(uzenet.id)
FROM uzenet, hirfolyam
WHERE h_id=hirfolyam.id
GROUP BY hirfolyam.id
ORDER BY 2 DESC;