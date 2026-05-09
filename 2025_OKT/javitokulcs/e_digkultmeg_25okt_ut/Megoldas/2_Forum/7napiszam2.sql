SELECT COUNT(*)
FROM (
	SELECT f_id
	FROM uzenet
	GROUP BY f_id
	) AS egyedi;