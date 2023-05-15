using lottóFeladat;
using System.IO;

//1. Hozzd létre a listát
List<data> adatok = new List<data>();

//2. Olvasd be a txt fájlt
string[] lines = File.ReadAllLines("lotto.txt");
foreach(var item in lines)
{
    string[] values = item.Split(";");

    data adatObject = new data(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]),
        int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
    adatok.Add(adatObject);
}
//Kérj be egy hétszámot, majd írd ki annaka hétnek a nyerő számait.
Console.Write("Írj be egy hétszámmot: (1-52): ");
int inputSzam = int.Parse(Console.ReadLine());
foreach(var item in adatok)
{
    if (item.week == inputSzam)
    {
        Console.WriteLine(inputSzam+". hét nyerő számai: "+item.numOne+","+item.numTwo+","
            +item.numThree+","+item.numFour+","+item.numFive);
    }
}
//4. Menj végig az adatok listán, és növeld a számok előfordulásainak számát a szótárban
Dictionary<int, int> szamok = new Dictionary<int, int>();
foreach (var item in adatok)
{
    int[] nyeroszamok = new int[] { item.numOne, item.numTwo, item.numThree, item.numFour, item.numFive }; //Egybe lett kenve az összes szám, így meg lehet számolni melyikből mennyi van.
    foreach (int num in nyeroszamok)
    {
        if (szamok.ContainsKey(num))
        {
            szamok[num]++;
        }
        else
        {
            szamok.Add(num, 1);
        }
    }
}
//5. Találd meg a szótárban a legkisebb előfordulási értéket és a hozzá tartozó számot
int legkevesebbElofordulas = int.MaxValue;
int legkevesebbSzam = -1;

foreach (var entry in szamok)
{
    if (entry.Value < legkevesebbElofordulas)
    {
        legkevesebbElofordulas = entry.Value;
        legkevesebbSzam = entry.Key;
    }
}
Console.WriteLine("Legkevesebbszer előforduló szám: "+legkevesebbSzam+" ennyiszer fordult elő: "+legkevesebbElofordulas);
//6. Hányszor húztak páros számot ?
int párosok = 0;
foreach(var item in adatok)
{
    if (item.numOne % 2 == 0) párosok += 1;
    if (item.numTwo % 2 == 0) párosok += 1;
    if (item.numThree % 2 == 0) párosok += 1;
    if (item.numFour % 2 == 0) párosok += 1;
    if (item.numFive % 2 == 0) párosok += 1;
}
Console.WriteLine("Ennyi páros szám van: "+párosok);
int numberFives = 0;
foreach (var item in adatok)
{
    if (item.numOne == 5) numberFives += 1;
    if (item.numTwo == 5) numberFives += 1;
    if (item.numThree == 5) numberFives += 1;
    if (item.numFour == 5) numberFives += 1;
    if (item.numFive == 5) numberFives += 1;
}
Console.WriteLine("Ennyi 5-ös szám van: "+numberFives);
int fortySix = 0;
foreach (var item in adatok)
{
    if (item.numOne == 46) fortySix += 1;
    if (item.numTwo == 46) fortySix += 1;
    if (item.numThree == 46) fortySix += 1;
    if (item.numFour == 46) fortySix += 1;
    if (item.numFive == 46) fortySix += 1;
}
Console.WriteLine("Ennyi 46-os szám volt: " + fortySix);
//7. Írd ki 1-90-ig a számokat és az előfordulásuk számát
Console.WriteLine("1-től 90-ig a kihúzott számok és az előfordulásuk száma:");
for (int i = 1; i <= 90; i++)
{
    if (szamok.ContainsKey(i))
    {
        Console.WriteLine(i + " - " + szamok[i] + " alkalommal");
    }
    else
    {
        Console.WriteLine(i + " - 0 alkalommal");
    }
}