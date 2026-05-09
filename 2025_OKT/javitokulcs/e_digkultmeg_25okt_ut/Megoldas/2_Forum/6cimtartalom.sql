SELECT veznev, utonev, tartalom, kuldido
FROM felhasznalo, uzenet, hirfolyam
WHERE felhasznalo.id=f_id AND tartalom LIKE CONCAT('%',megnevezes,'%');