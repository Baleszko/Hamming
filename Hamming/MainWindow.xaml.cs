using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
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

namespace Hamming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Kodolo
    {
        /* A Hamming 7 4 megvalósítása a feladat, így egy 7 elemő tömböt
         hozok létre, hogy a felhasználó álltal megadott bitek mellett a 3 paritás bit is elférjen benne */
        
        private int[] kodolt = new int[7];     
        
        public Kodolo(int digit0, int digit1, int digit2, int digit3)
        {
            //Itt kerül átadásra a szövegbevitelő mező értéke ennek az osztálynak. 
            int[] kod = new int[4];
            kod[0] = digit0;
            kod[1] = digit1;
            kod[2] = digit2;
            kod[3] = digit3;

            // Itt hozom létre a paritás biteket, az eredeti 4 bitból(a '^' kizáró vagy operátor segítségével) 
            int[] paritas = new int[3];

            paritas[0] = kod[0] ^ kod[1] ^ kod[2];
            paritas[1] = kod[0] ^ kod[1] ^ kod[3];
            paritas[2] = kod[0] ^ kod[2] ^ kod[3];

            //Ezután feltöltöm a kész elemeket sorrendben a program elején létrehozott tömbbe

            kodolt[0] = kod[0];
            kodolt[1] = kod[1];
            kodolt[2] = kod[2];
            kodolt[3] = paritas[0];
            kodolt[4] = kod[3]; 
            kodolt[5] = paritas[1];
            kodolt[6] = paritas[2];

        }

        // A számokat egymás mellé illesztem és string formátummá konvertálom, ezt a függvényt hívom meg a kiíratásnál

        public string Getkodolt()
        {
            string kodolkiir = string.Join("", kodolt);
            return kodolkiir;
        }

    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            // Négy segéd változót deklaráltam, amik a kiolvassák a szövegbeviteli mezőkből az értékeket. 
            int beker0 = 0;
            int beker1 = 0;
            int beker2 = 0;
            int beker3 = 0;

            //Megvizsgálom, hogy ezek az értékek megfelelőek-e(0 vagy 1 értékűek), ha nem tájékoztatom a felhasználót, hogy nem megfelelő a formátum.
            if ((tbAdatBe0.Text == "0" || tbAdatBe0.Text == "1") && (tbAdatBe1.Text == "0" || tbAdatBe1.Text == "1")
                && (tbAdatBe2.Text == "0" || tbAdatBe2.Text == "1") && (tbAdatBe3.Text == "0" || tbAdatBe3.Text == "1"))
            {
                // Ha viszont megfelel, string tipusból számmá alakítom őket, majd átadom őket paraméterként a Kodolo osztály konstruktorának.
                 beker0 = Int32.Parse(tbAdatBe0.Text);
                 beker1 = Int32.Parse(tbAdatBe1.Text);
                 beker2 = Int32.Parse(tbAdatBe2.Text);
                 beker3 = Int32.Parse(tbAdatBe3.Text);

                Kodolo kodolo = new Kodolo(beker0, beker1, beker2, beker3);
                lbkiir.Content = kodolo.Getkodolt();
            }
            else
            {
                lbkiir.Content = "Nem megfelelő formátum!";
            }

            

        }
    }
}
