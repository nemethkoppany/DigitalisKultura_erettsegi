--2
SELECT hirfolyam.megnevezes, felhasznalo.veznev, felhasznalo.utonev, felhasznalo.email 
FROM hirfolyam, felhasznalo
WHERE hirfolyam.moderator = felhasznalo.id

--3
SELECT uzenet.tartalom 
FROM uzenet
WHERE uzenet.tartalom LIKE "%bike" OR uzenet.tartalom LIKE "%bicikli"

--4
SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo
GROUP BY felhasznalo.veznev, felhasznalo.utonev
HAVING COUNT(felhasznalo.id) > 1
ORDER BY 1, 2;

--5
SELECT hirfolyam.megnevezes, COUNT(uzenet.id)
FROM hirfolyam, uzenet
WHERE uzenet.h_id = hirfolyam.id
GROUP BY hirfolyam.id
ORDER BY 2;

--6
SELECT felhasznalo.veznev, felhasznalo.utonev, uzenet.tartalom, uzenet.kuldido
FROM felhasznalo, uzenet, hirfolyam
WHERE felhasznalo.id = uzenet.f_id AND uzenet.tartalom LIKE CONCAT( "%", hirfolyam.megnevezes,"%")

--7
SELECT COUNT(seged.id)
FROM (SELECT DISTINCT felhasznalo.id
	FROM felhasznalo, uzenet
	WHERE felhasznalo.id = uzenet.f_id) AS seged

--VAGY

SELECT COUNT(DISTINCT f_id)
FROM uzenet

--VAGY

SELECT COUNT(*)
FROM (
    SELECT f_id
    FROM uzenet
    GROUP BY f_id
	) AS egyedi

--8
SELECT felhasznalo.veznev, felhasznalo.utonev
FROM felhasznalo
WHERE felhasznalo.utolso <= "2010-01-01" 
AND felhasznalo.id NOT IN (SELECT uzenet.f_id FROM uzenet)

--9
SELECT felhasznalo.veznev, felhasznalo.utonev, COUNT(uzenet.id)
FROM felhasznalo, uzenet, hirfolyam
WHERE felhasznalo.id = uzenet.f_id 
AND hirfolyam.id = uzenet.h_id 
AND hirfolyam.megnevezes = "e-bike" 
AND uzenet.kuldido >= "12:00:00" 
AND uzenet.kuldido <= "16:00:00"
GROUP BY felhasznalo.id;

--10
SELECT uzenet.kuldido 
FROM 

    ( SELECT uzenet.f_id
     FROM uzenet
     ORDER BY uzenet.kuldido
     LIMIT 1) AS elso_ember, uzenet
     
 WHERE uzenet.f_id = elso_ember.f_id
 ORDER BY uzenet.kuldido DESC
 LIMIT 1

 --VAGY 

 SELECT kuldido
FROM uzenet
WHERE f_id = (
    SELECT f_id
    FROM uzenet
ORDER BY kuldido
 LIMIT 1
    )
    ORDER BY kuldido DESC
    LIMIT 1