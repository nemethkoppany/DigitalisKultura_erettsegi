SELECT SUM(ar*0.015)
FROM hirdetes
WHERE allapot='eladva'
	AND YEAR(datum)=2021;