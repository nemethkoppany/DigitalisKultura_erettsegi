SELECT veznev, utonev, COUNT(*)
FROM felhasznalo, uzenet, hirfolyam
WHERE felhasznalo.id=f_id AND hirfolyam.id=h_id AND megnevezes='e-bike' AND
	kuldido BETWEEN '12:00:00' AND '16:00:00'
GROUP BY uzenet.f_id;