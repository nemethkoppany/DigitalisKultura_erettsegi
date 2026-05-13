# Autók mozgása

jeladas = list()

def fel1() :
    #print('1. feladat:')
    be = open("jeladas.txt","rt")
    for sor in be :
        szet = sor.split()
        egy = [ szet[0], int(szet[1]), int(szet[2]), int(szet[3]) ]
        jeladas.append(egy)
    be.close()

def fel2() :
    print('2. feladat:')
    print(f"Az utolsó jeladás időpontja {jeladas[-1][1]}:{jeladas[-1][2]}, a jármű rendszáma {jeladas[-1][0]}")


def fel3() :
    print('3. feladat:')
    rsz = jeladas[0][0]
    print('Az első jármű:',rsz)
    print('Jeladásainak időpontjai: ', end="")
    for jel in jeladas :
        if rsz == jel[0] :
            print(f"{jel[1]}:{jel[2]}",end=' ')
    print()

def fel4() :
    print('4. feladat:')
    ora = int(input('Kérem adja meg az órát: '))
    perc = int(input('Kérem adja meg a percet: '))
    db = 0
    for jel in jeladas :
        if jel[1] == ora and jel[2] == perc :
            db += 1
    print('A jeladások száma:',db)

def fel5() :
    print('5. feladat:')
    maxseb = 0
    for jel in jeladas :
        if jel[3]>maxseb :
            maxseb = jel[3]
    print('A legnagyobb sebesség km/h:', maxseb)
    print('A járművek:', end=' ')
    for jel in jeladas :
        if jel[3] == maxseb :
            print(jel[0], end=' ')
    print()


def fel6() :
    print('6. feladat:')
    rsz = input('Kérem adja meg a rendszámot: ')
    i = 0
    while i < len(jeladas) and jeladas[i][0] != rsz :
        i += 1
    if i<len(jeladas) :
        tav = 0.0
        ora = jeladas[i][1]
        perc = jeladas[i][2]
        seb = jeladas[i][3]
        print(f"{ora}:{perc} {tav:.1f} km")
        for j in range(i+1,len(jeladas)) :
            if jeladas[j][0] == rsz :
                ujora = jeladas[j][1]
                ujperc = jeladas[j][2]
                elt = ujora - ora + (ujperc-perc) / 60
                tav += seb*elt
                ora = ujora
                perc = ujperc
                seb = jeladas[j][3]
                print(f"{ora}:{perc} {tav:.1f} km")
    else :
        print('Nincs ilyen rendszámmal jármű.')

def fel7() :
    #print('7. feladat:')
    elsout = list()

    for jel in jeladas :
        i = 0
        while (i<len(elsout)) and elsout[i][0]!=jel[0] :
            i += 1
        if i<len(elsout) :
            elsout[i][3] = jel[1]
            elsout[i][4] = jel[2]
        else :
            elso = [jel[0], jel[1], jel[2], 0, 0 ]
            elsout.append(elso)
    ki = open("ido.txt","wt")
    for eu in elsout :
        print( eu[0], eu[1], eu[2], eu[3], eu[4], file=ki )

    ki.close()

# Főprogram
fel1()
fel2()
fel3()
fel4()
fel5()
fel6()
fel7()



