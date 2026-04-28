SELECT uzenet.kuldido
FROM (

	SELECT uzenet.f_id
	FROM uzenet
	ORDER BY uzenet.kuldido ASC
	LIMIT 1
    ) AS elso_ember, uzenet
WHERE uzenet.f_id = elso_ember.f_id
ORDER BY uzenet.kuldido DESC
LIMIT 1