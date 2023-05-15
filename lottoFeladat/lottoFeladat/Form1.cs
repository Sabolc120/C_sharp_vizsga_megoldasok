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

            // L�trehozunk egy list�t, amely az adatokat t�rolja
            string[] lines = File.ReadAllLines("lotto.txt");
            foreach (var item in lines)
            {
                // Beolvassuk a f�jlb�l a nyer�sz�mokat �s elt�roljuk a list�ban
                string[] values = item.Split(";");

                data adatObject = new data(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]),
                    int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
                adatok.Add(adatObject);
            }
            // A f�ggv�nyeket megh�vjuk, hogy az adatokat feldolgozz�k
            countNumbs();
            mostOftenNumber();
            equalNums();
            numFours();
            numSeventyThrees();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Ebben a f�ggv�nyben megsz�moljuk, hogy melyik sz�m h�nyszor fordul el�
        public void countNumbs()
        {
            // L�trehozunk egy sz�t�rat, amely a sz�mok el�fordul�sait t�rolja
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
            // A dataGridView1-be felt�ltj�k a sz�mok el�fordul�sait
            foreach (var entry in szamok)
            {
                dataGridView1.Rows.Add(entry.Key, entry.Value);
            }
        }
        // Ebben a f�ggv�nyben lek�rdezz�k a nyer�sz�mokat egy adott h�ten
        public void getWeek()
        {
            int pickedWeek = Convert.ToInt32(numericUpDown1.Value);

            foreach (var item in adatok)
            {
                if (pickedWeek == item.week)
                {
                    label1.Text = "2. Feladat, a " + pickedWeek + " h�ten, a nyer� sz�mok a k�vetkez�k: "
                        + item.numOne + "," + item.numTwo + "," + item.numThree + "," + item.numFour + "," + item.numFive;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWeek();
        }
        // Ebben a f�ggv�nyben megtal�ljuk a leggyakrabban el�fordul� sz�mot
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
            label2.Text= "Leggyakrabban el�fordul� sz�m: " + leggyakoribbSzam + " ennyiszer fordult el�: " + legtobbElofordulas;

        }
        //P�ros sz�mokat keress�k meg
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
            label3.Text = "3. Feladat, ennyi p�ros sz�m volt: " + parosSzamok;
        }
        //�ssze sz�moljuk mennyi 4-es van.
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
            label4.Text = "4.Feladat, ennyi n�gyes sz�m volt: " + numberOfFours;
        }
        //�ssze sz�moljuk mennyi 73-as van.
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
            label5.Text = "5.Feladat, ennyi 73-as sz�m volt: " + numberOfSeventyThrees;
        }
    }
}