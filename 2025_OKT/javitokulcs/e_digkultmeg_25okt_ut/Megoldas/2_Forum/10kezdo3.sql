SELECT MAX(uzenet.kuldido)
FROM uzenet
WHERE uzenet.f_id = (SELECT uzenet.f_id
					FROM uzenet
					WHERE uzenet.kuldido =
						(SELECT MIN(uzenet.kuldido)
						FROM uzenet));
