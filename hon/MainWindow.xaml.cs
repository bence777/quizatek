using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random random = new Random();
        public List<Kerdes> kerdesek;
        public MainWindow()
        {
            InitializeComponent();
            kerdesek = new List<Kerdes>
            {
                new Kerdes("Mikor született 7Street?", new string[] { "2006 01.19.", "2005 01.19","2005 10. 19.","2006 10. 19." }),
                new Kerdes("Mekkora a népsűrűsége Európának?", new string[] { "212 fő/km²" , "69 fő/km²", "420 fő/km²", "112 fő/km²" }),
                new Kerdes("Melyik évben alakult az ENSZ?", new string[] { "1955","1944","1945","1946" }),
                new Kerdes("Melyik bolygó a Naprendszer legnagyobbika?", new string[] { "Mars","Jupiter","Neptunusz","Föld" }),
                new Kerdes("Ki írta a Romeó és Júlia című tragédiát?", new string[] { "William Shakespeare", "Berzsenyi Dániel","Janus Pannonius","Ekhoe" }),
                new Kerdes("Melyik város a világ legnépesebb városa?", new string[] { "Miskolc", "New York", "Tokió", "Peking" }),
                new Kerdes("Melyik számnak  a Sinusa egyenlő eggyel?", new string[] { "26700","5130","8900","180" }),
                new Kerdes("Melyik NEM OTL tag?", new string[] { "AKC Misi","Ekhoe","Pogányinduló","Gyuris" }),
                new Kerdes("Melyik a legelső magyar írás?", new string[] { "Halotti Beszéd", "Ómagyar Mária-Siralom","Nemzeti Dal","BSW - Csöcsöl És Segg" }),
                new Kerdes("Hány kontinens van a földon?", new string[] { "1","7","0","6" }),
                new Kerdes("Mekkora a Föld tömege? (kilogramm)", new string[] { "9,79 x 10^57", "5,97 x 10^24", "1,57 x 9^79","Egyikse" }),
                new Kerdes("Mekkora körülbelüla Naprendszerünk térfogata? (köbkilóméter)", new string[] { "5,281 x 20^81 ", "9,412 x 37^18 ", "1,974 x 9^48", "1,412 x 10^18 " }),



            };
            szam = random.Next(0, kerdesek.Count);
            FrissitKerdestEsValaszokat();
            UjKerdes();
            changeplayer();

        }

        private void FrissitKerdestEsValaszokat()
        {
            // Kérdés beállítása
            kerdes.Text = kerdesek[szam].KerdesSzoveg;

            // Válaszok beállítása a gombokra
            valasz.Content = kerdesek[szam].Valaszok[0];
            valasz1.Content = kerdesek[szam].Valaszok[1];
            valasz2.Content = kerdesek[szam].Valaszok[2];
            valasz3.Content = kerdesek[szam].Valaszok[3];
        }

        public int[] hasznalt = new int[12];
        int idk;
        public int szamlalo = 0;
        private void UjKerdes()
        {
            szamlalo++;
            szamlal.Text = szamlalo + "/12";
            if (szamlalo > 12)
            {
                this.Close();
            }


            // Új véletlenszerű kérdés kiválasztása
            szam = random.Next(0, kerdesek.Count);
            hasznalt[idk] = szam;
            while (hasznalt.Contains(szam))
            {
                szam = random.Next(0, kerdesek.Count);
            }


            // Kérdés és válaszok beállítása a vezérlőknek
            kerdes.Text = kerdesek[szam].KerdesSzoveg;
            valasz.Content = kerdesek[szam].Valaszok[0];
            valasz1.Content = kerdesek[szam].Valaszok[1];
            valasz2.Content = kerdesek[szam].Valaszok[2];
            valasz3.Content = kerdesek[szam].Valaszok[3];
            idk++;
        }
        private void UjKerdesButton_Click(object sender, RoutedEventArgs e)
        {
            // Új véletlenszerű kérdés kiválasztása és frissítése
            szam = random.Next(0, kerdesek.Count);
            FrissitKerdestEsValaszokat();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            changeplayer();
            UjKerdes();

        }

        /*
        public string[] kerdesek = new string[] { "Mikor született 7Street?" , "Mekkora a népsűrűsége Európának?", "Melyik évben alakult az ENSZ?", "Melyik bolygó a Naprendszer legnagyobbika?" };
        public string[] valaszok = new string[] { "2006 01.19.", "2005 01.19","2005 10. 19.","2006 10. 19." , "212 fő/km²" , "69 fő/km²", "420 fő/km²", "112 fő/km²","1955","1944","1945","1946","Mars","Jupiter","Neptunusz","Föld" };
        */
        public int szam;
        public int szam2;
        public bool helyes = false;
        public int player = 0;

        public int p1point = 0;
        public int p2point = 0;
        public int player2 = 1;

        public int kerdesszam;

        public Random r = new Random();
        public Random rr = new Random();



        public void changeplayer()
        {

            //player váltás
            if (player % 2 == 1)
            {
                player2 = 1;
                p1.Foreground = Brushes.Blue;
                p2.Foreground = Brushes.Black;


            }

            if (player % 2 == 0)
            {
                player2 = 2;
                p2.Foreground = Brushes.Blue;
                p1.Foreground = Brushes.Black;
            }
            player++;



        }






        private void valasz3_Click(object sender, RoutedEventArgs e)
        {
            if (szam == 1 && player2 == 1 || szam == 5 && player2 == 1 || szam == 11 && player2 == 1)
            {
                p1point += 1;
                p1.Text = "Player 1: " + p1point + " pont";
            }

            if (szam == 1 && player2 == 2 || szam == 5 && player2 == 2 || szam == 11 && player2 == 2)
            {
                p2point += 1;
                p2.Text = "Player 1: " + p2point + " pont";

            }
            changeplayer();
            UjKerdes();
        }

        private void valasz1_Click(object sender, RoutedEventArgs e)
        {
            if (szam == 3 && player2 == 1 || szam == 6 && player2 == 1 || szam == 9 && player2 == 1 || szam == 10 && player2 == 1)
            {
                p1point += 1;
                p1.Text = "Player 1: " + p1point + " pont";
            }

            if (szam == 3 && player2 == 2 || szam == 6 && player2 == 2 || szam == 9 && player2 == 2 || szam == 10 && player2 == 2)
            {
                p2point += 1;
                p2.Text = "Player 1: " + p2point + " pont";

            }
            changeplayer();
            UjKerdes();
        }

        private void valasz2_Click(object sender, RoutedEventArgs e)
        {
            if (szam == 2 && player2 == 1 || szam == 7 && player2 == 1)
            {
                p1point += 1;
                p1.Text = "Player 1: " + p1point + " pont";
            }

            if (szam == 2 || szam == 7 && player2 == 2)
            {
                p2point += 1;
                p2.Text = "Player 1: " + p2point + " pont";

            }
            changeplayer();
            UjKerdes();
        }

        private void valasz_Click(object sender, RoutedEventArgs e)
        {
            if (szam == 0 && player2 == 1 || szam == 4 && player2 == 1 || szam == 8 && player2 == 1)
            {
                p1point += 1;
                p1.Text = "Player 1: " + p1point + " pont";
            }

            if (szam == 0 && player2 == 2 || szam == 4 && player2 == 2 || szam == 8 && player2 == 2)
            {
                p2point += 1;
                p2.Text = "Player 1: " + p2point + " pont";

            }
            UjKerdes();

        }
    }

    public class Kerdes
    {
        public string KerdesSzoveg { get; }
        public string[] Valaszok { get; }

        public Kerdes(string kerdesSzoveg, string[] valaszok)
        {
            KerdesSzoveg = kerdesSzoveg;
            Valaszok = valaszok;
        }
    }
}
