SELECT kuldido
FROM uzenet
WHERE f_id=(
	SELECT f_id
	FROM uzenet
	ORDER BY kuldido
	LIMIT 1
	)
ORDER BY kuldido DESC
LIMIT 1;