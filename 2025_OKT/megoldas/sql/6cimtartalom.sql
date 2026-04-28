SELECT felhasznalo.veznev, felhasznalo.utonev, uzenet.tartalom, uzenet.kuldido
FROM felhasznalo, uzenet,hirfolyam
WHERE felhasznalo.id = uzenet.f_id
AND uzenet.tartalom LIKE CONCAT("%",hirfolyam.megnevezes,"%") 