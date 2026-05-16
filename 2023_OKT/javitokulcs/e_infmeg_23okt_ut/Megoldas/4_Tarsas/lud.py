ösvények = []
with open("osvenyek.txt") as beösvények:
    for sor in beösvények:
        ösvények.append(sor.strip())

dobások = []
with open("dobasok.txt") as bedobások:
    sor = bedobások.readline()
    dobások = sor.strip().split()
dobások = list(map(int, dobások))

print("2. feladat")
print(f"A dobások száma: {len(dobások)}")
print(f"Az ösvények száma: {len(ösvények)}")

print("\n3. feladat")
maxösvény = 0
for i in range(1, len(ösvények)):
    if len(ösvények[i]) > len(ösvények[maxösvény]):
        maxösvény = i 
print(f"Az egyik leghosszabb a(z) {maxösvény+1}. ösvény, hossza: {len(ösvények[maxösvény])}")

print("\n4. feladat")
ösvénysorszám = int(input("Adja meg egy ösvény sorszámát! "))
játékosszám = int(input("Adja meg a játékosok számát! "))
ösvény =  ösvények[ösvénysorszám-1]

print("\n5. feladat")
stat = {}
for betű in ösvény:
    if betű not in stat:
        stat[betű] = 0
    stat[betű] += 1

for betű in stat:
    print(f"{betű}: {stat[betű]} darab")

# print("\n6. feladat")
kimenet = open("kulonleges.txt", "w")
sorszám = 0
for mező in ösvény:
    sorszám += 1
    if mező != "M":
        print(sorszám, mező, sep="\t", file=kimenet)
kimenet.close()

print("\n7. feladat")
kör = 0
maxtáv = 0
megtett = [0, 0, 0, 0, 0]
while maxtáv < len(ösvény):
    for játékos in range(játékosszám):
        megtett[játékos] += dobások[kör*játékosszám+játékos]
        maxtáv = max(maxtáv, megtett[játékos])
    kör += 1
print(f"A játék a(z) {kör}. körben fejeződött be. A legtávolabb jutó(k) sorszáma: ", end=" ")
for játékos in range(játékosszám):
    if megtett[játékos] == maxtáv:
        print(játékos+1, end=" ")

print("\n\n8. feladat")
ösvény =  ösvények[ösvénysorszám-1]
kör = 0
maxtáv = 0
megtett = [0, 0, 0, 0, 0]
while maxtáv < len(ösvény):
    for játékos in range(játékosszám):
        dobás = dobások[kör*játékosszám+játékos]
        megtett[játékos] += dobás
        if megtett[játékos] <= len(ösvény):
            if ösvény[megtett[játékos]-1] == "E":
                megtett[játékos] += dobás
            elif ösvény[megtett[játékos]-1] == "V":
                megtett[játékos] -= dobás
        maxtáv = max(maxtáv, megtett[játékos])
    kör += 1
print("Nyertes(ek):", end=" ")
for játékos in range(játékosszám):
    if megtett[játékos]  >= len(ösvény):
        print(játékos+1, end=" ")
print(f"\nA többiek pozíciója:")
for játékos in range(játékosszám):
    if megtett[játékos] < len(ösvény):
        print(f"{játékos+1}. játékos, {megtett[játékos]}. mező")

