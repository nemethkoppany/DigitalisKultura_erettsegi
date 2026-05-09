határok = []
with open("ut.txt") as bemenet:
    hossz = int(bemenet.readline().strip())
    for sor in bemenet:
        határ = sor.strip().split()
        határ[0] = int(határ[0])
        határok.append(határ)

print("2. feladat")
print("A települések neve:")
for határ in határok:
    if len(határ[1]) > 3:
        print(határ[1])

print("\n3. feladat")
vizsgált = float(input("Adja meg a vizsgált szakasz hosszát km-ben! "))
minsebesség = 90
for határ in határok:
    if határ[0] <= vizsgált*1000:
        if len(határ[1]) > 3:
            minsebesség = min(minsebesség, 50)
        if len(határ[1]) == 2:
            minsebesség = min(int(határ[1]), minsebesség)
print(f"Az első {vizsgált} km-en {minsebesség} km/h volt a legalacsonyabb megengedett sebesség.")

print("\n4. feladat")
bent =0
for határ in határok:
    if len(határ[1]) > 3:
        bent -= határ[0]
    elif határ[1] == "]":
        bent += határ[0]
arány = 100*bent/hossz
print(f"Az út {arány:.2f} százaléka vezet településen belül.")

print("\n5. feladat")
keresett = input("Adja meg egy település nevét! ")
táblákszáma = 0
i = 0
while határok[i][1] != keresett:
    i += 1
kezdet = határok[i][0]
while határok[i][1] != "]":
    i += 1
    if len(határok[i][1]) == 2:
        táblákszáma += 1
vég = határok[i][0]
print(f"A sebességkorlátozó táblák száma: {táblákszáma}")
print(f"Az út hossza a településen belül {vég-kezdet} méter.")

print("\n6. feladat")
i = 0
előzővége = -1
következőkezdete = -1
while határok[i][1] != keresett:
    if len(határok[i][1]) > 3:
        előzőneve = határok[i][1]
    if határok[i][1] == "]":
        előzővége = határok[i][0]
    i += 1
kezdet = határok[i][0]
while határok[i][1] != "]":
    i += 1
vég = határok[i][0]
while i < len(határok) and len(határok[i][1]) <= 3:
    i += 1
if i < len(határok):
    következőneve = határok[i][1]
    következőkezdete = határok[i][0]
if előzővége == -1:
    legközelebbineve = következőneve
elif következőkezdete == -1:
    legközelebbineve = előzőneve
else:
    if kezdet - előzővége <= következőkezdete - vég:
        legközelebbineve = előzőneve
    else:
        legközelebbineve = következőneve
print(f"A legközelebbi település: {legközelebbineve}")

