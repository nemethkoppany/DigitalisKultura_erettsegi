SELECT felhasznalo.veznev, felhasznalo.utonev, COUNT(uzenet.id)
FROM felhasznalo, uzenet, hirfolyam
WHERE felhasznalo.id = uzenet.f_id AND hirfolyam.id = uzenet.h_id
AND hirfolyam.megnevezes = "e-bike" AND uzenet.kuldido >= "12:00:00" AND uzenet.kuldido <= "16:00:00"
GROUP BY felhasznalo.id