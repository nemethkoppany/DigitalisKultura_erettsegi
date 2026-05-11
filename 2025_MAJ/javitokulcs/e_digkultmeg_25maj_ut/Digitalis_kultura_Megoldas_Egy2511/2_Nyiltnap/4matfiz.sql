SELECT csoport, targy, datum
FROM orak
WHERE csoport Like '9%' AND (targy='matematika' Or targy='fizika')
ORDER BY targy;
