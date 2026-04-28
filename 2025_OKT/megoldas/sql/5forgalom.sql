SELECT hirfolyam.megnevezes, COUNT(uzenet.id)
FROM hirfolyam
INNER JOIN uzenet ON uzenet.h_id = hirfolyam.id
GROUP BY hirfolyam.id
ORDER BY COUNT(uzenet.id) DESC