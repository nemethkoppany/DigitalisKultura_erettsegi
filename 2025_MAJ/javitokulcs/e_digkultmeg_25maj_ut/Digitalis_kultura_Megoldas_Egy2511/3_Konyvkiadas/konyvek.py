# Ifjúsági Könyvek

EV = 0
NEGYEDEV = 1
EREDET = 2
LEIRAS = 3
PLDSZAM = 4

def feladat1() :
    kiadasok = list()
    be = open("kiadas.txt",encoding="utf-8")
    for sor in be :
        sor = sor.strip()
        if sor != "" :
            sorfeldb = sor.split(';')
            kiadas = [ int(sorfeldb[EV]), int(sorfeldb[NEGYEDEV]), sorfeldb[EREDET],  sorfeldb[LEIRAS], int(sorfeldb[PLDSZAM]) ]
            kiadasok.append(kiadas)
    be.close()
    return kiadasok

def feladat2(kiadasok) :
    print("2. feladat:")
    szerzo = input("Szerző: ")
    kiadtak = 0
    for kiadas in kiadasok :
        if szerzo in kiadas[LEIRAS] : 
            kiadtak += 1
    if kiadtak>0 :
        print(kiadtak, "könyvkiadás")
    else :
        print("Nem adtak ki")

def feladat3(kiadasok) :
    print("3. feladat:")
    legnagyobb = 0
    alkalom = 0
    for kiadas in kiadasok :
        if kiadas[PLDSZAM] > legnagyobb :
            legnagyobb = kiadas[PLDSZAM]
            alkalom = 1
        elif kiadas[PLDSZAM] == legnagyobb :
            alkalom += 1
    print(f"Legnagyobb példányszám: {legnagyobb}, előfordult {alkalom} alkalommal")

def feladat4(kiadasok) :
    print("4. feladat:")
    ki = 0
    while not (kiadasok[ki][EREDET] == "kf" and kiadasok[ki][PLDSZAM] >= 40000 ) :
        ki += 1
    print(f"{kiadasok[ki][EV]}/{kiadasok[ki][NEGYEDEV]}. {kiadasok[ki][LEIRAS]}")

def feladat5(kiadasok) :
    print("5. feladat:")
    darab = [ [0,0],[0,0],[0,0],[0,0] ]
    kiad_stat = [ [0,0] for _ in range(4) ]
    for kiadas in kiadasok :
        evind = kiadas[EV]-2020
        if kiadas[EREDET] == "ma" :
            nyind = 0
        else :
            nyind = 1
        darab[evind][nyind] += kiadas[PLDSZAM]
        kiad_stat[evind][nyind] += 1
    print("Év\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\tKülföldi példányszám")
    for ev in range(2020,2023+1) :
        evind = ev - 2020
        print(f"{ev}\t\t{kiad_stat[evind][0]}\t\t{darab[evind][0]}\t\t{kiad_stat[evind][1]}\t\t{darab[evind][1]}")

    with open("tabla.html","wt",encoding="utf-8") as ki :
        print("<table>", file=ki)
        print("<tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi kiadás</th><th>Külföldi példányszám</th></tr>",file=ki)
        for ev in range(2020,2023+1) :
            evind = ev - 2020
            print(f"<tr><td>{ev}</td><td>{kiad_stat[evind][0]}</td><td>{darab[evind][0]}</td><td>{kiad_stat[evind][1]}</td><td>{darab[evind][1]}</td></tr>",file=ki)
        print("</table>", file=ki)

def feladat6(kiadasok) :
    print("6. feladat:")
    konyv_peldanyok = dict()
    for kiadas in kiadasok :
        if kiadas[LEIRAS] in konyv_peldanyok :
            konyv_peldanyok[kiadas[LEIRAS]].append(kiadas[PLDSZAM])
        else :
            konyv_peldanyok[kiadas[LEIRAS]] = [kiadas[PLDSZAM]]
    print("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek:")
    for konyv,peldanyok in konyv_peldanyok.items() :
        nagyobb = 0
        idoszak = 1
        while idoszak < len(peldanyok) and nagyobb < 2 :
            if peldanyok[idoszak]>peldanyok[0] :
                nagyobb += 1
            idoszak += 1
        if nagyobb >= 2 :
            print(konyv)

kiadasok = feladat1()
feladat2(kiadasok)
feladat3(kiadasok)
feladat4(kiadasok)
feladat5(kiadasok)
feladat6(kiadasok)

