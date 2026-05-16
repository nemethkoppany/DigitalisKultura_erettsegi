SELECT szakkor.nev, szakkor.tanar
FROM szakkor
WHERE szakkor.nev LIKE "%programoz%" OR szakkor.nev LIKE "%robotika%"
