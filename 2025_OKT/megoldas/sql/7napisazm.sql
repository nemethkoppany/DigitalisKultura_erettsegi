SELECT COUNT(seged.id)
FROM (SELECT DISTINCT felhasznalo.id
	FROM felhasznalo, uzenet
	WHERE felhasznalo.id = uzenet.f_id) AS seged