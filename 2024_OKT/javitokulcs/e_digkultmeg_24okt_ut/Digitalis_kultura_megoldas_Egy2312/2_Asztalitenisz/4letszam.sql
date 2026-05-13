SELECT Count(*), if(neme=0,"nő","férfi")
FROM jatekos
GROUP BY neme;
