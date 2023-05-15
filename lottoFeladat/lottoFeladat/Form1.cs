using System.Data;
using System.IO;
namespace lottoFeladat
{
    public partial class Form1 : Form
    {

        static List<data> adatok = new List<data>();
        public Form1()
        {
            InitializeComponent();

            // Létrehozunk egy listát, amely az adatokat tárolja
            string[] lines = File.ReadAllLines("lotto.txt");
            foreach (var item in lines)
            {
                // Beolvassuk a fájlból a nyerõszámokat és eltároljuk a listában
                string[] values = item.Split(";");

                data adatObject = new data(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]),
                    int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
                adatok.Add(adatObject);
            }
            // A függvényeket meghívjuk, hogy az adatokat feldolgozzák
            countNumbs();
            mostOftenNumber();
            equalNums();
            numFours();
            numSeventyThrees();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Ebben a függvényben megszámoljuk, hogy melyik szám hányszor fordul elõ
        public void countNumbs()
        {
            // Létrehozunk egy szótárat, amely a számok elõfordulásait tárolja
            Dictionary<int, int> szamok = new Dictionary<int, int>();
            foreach (var item in adatok)
            {
                int[] nyeroszamok = new int[] { item.numOne, item.numTwo, item.numThree, item.numFour, item.numFive };
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

            
            dataGridView1.Rows.Clear();
            // A dataGridView1-be feltöltjük a számok elõfordulásait
            foreach (var entry in szamok)
            {
                dataGridView1.Rows.Add(entry.Key, entry.Value);
            }
        }
        // Ebben a függvényben lekérdezzük a nyerõszámokat egy adott héten
        public void getWeek()
        {
            int pickedWeek = Convert.ToInt32(numericUpDown1.Value);

            foreach (var item in adatok)
            {
                if (pickedWeek == item.week)
                {
                    label1.Text = "2. Feladat, a " + pickedWeek + " héten, a nyerõ számok a következõk: "
                        + item.numOne + "," + item.numTwo + "," + item.numThree + "," + item.numFour + "," + item.numFive;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWeek();
        }
        // Ebben a függvényben megtaláljuk a leggyakrabban elõforduló számot
        public void mostOftenNumber()
        {
            Dictionary<int, int> szamok = new Dictionary<int, int>();
            foreach (var item in adatok)
            {
                int[] nyeroszamok = new int[] { item.numOne, item.numTwo, item.numThree, item.numFour, item.numFive };
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
            int legtobbElofordulas = int.MinValue;
            int leggyakoribbSzam = -1;

            foreach (var entry in szamok)
            {
                if (entry.Value > legtobbElofordulas)
                {
                    legtobbElofordulas = entry.Value;
                    leggyakoribbSzam = entry.Key;
                }
            }
            label2.Text= "Leggyakrabban elõforduló szám: " + leggyakoribbSzam + " ennyiszer fordult elõ: " + legtobbElofordulas;

        }
        //Páros számokat keressük meg
        public void equalNums()
        {
            int parosSzamok = 0;
            foreach(var item in adatok)
            {
                if (item.numOne % 2 == 0) parosSzamok += 1;
                if (item.numTwo % 2 == 0) parosSzamok += 1;
                if (item.numThree % 2 == 0) parosSzamok += 1;
                if (item.numFour % 2 == 0) parosSzamok += 1;
                if (item.numFive % 2 == 0) parosSzamok += 1;
            }
            label3.Text = "3. Feladat, ennyi páros szám volt: " + parosSzamok;
        }
        //Össze számoljuk mennyi 4-es van.
        public void numFours()
        {
            int numberOfFours = 0;
            foreach (var item in adatok)
            {
                if (item.numOne  == 4) numberOfFours += 1;
                if (item.numTwo == 4) numberOfFours += 1;
                if (item.numThree == 4) numberOfFours += 1;
                if (item.numFour == 4) numberOfFours += 1;
                if (item.numFive == 4) numberOfFours += 1;
            }
            label4.Text = "4.Feladat, ennyi négyes szám volt: " + numberOfFours;
        }
        //Össze számoljuk mennyi 73-as van.
        public void numSeventyThrees()
        {
            int numberOfSeventyThrees = 0;
            foreach (var item in adatok)
            {
                if (item.numOne == 73) numberOfSeventyThrees += 1;
                if (item.numTwo == 73) numberOfSeventyThrees += 1;
                if (item.numThree == 73) numberOfSeventyThrees += 1;
                if (item.numFour == 73) numberOfSeventyThrees += 1;
                if (item.numFive == 73) numberOfSeventyThrees += 1;
            }
            label5.Text = "5.Feladat, ennyi 73-as szám volt: " + numberOfSeventyThrees;
        }
    }
}