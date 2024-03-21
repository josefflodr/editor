using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp18888
{
    public partial class MainWindow : Window
    {
        private string path = "FILE.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog()
            {
                Filter = "txt soubory (*.txt)|*.txt",
                Title = "Otevřít TXT soubor"
            };

            if (OD.ShowDialog() == true)
            {
                path = OD.FileName;
                WriteBTN.IsEnabled = true;
                precist(path);
            }
        }

        private void precist(string path)
        {
            TextVystup.Text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string radek;
                while ((radek = sr.ReadLine()) != null)
                {
                    TextVystup.Text += radek + "\n";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            
            string vstup = TextVstup.Text;
            string datum = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write($"{vstup} - {datum}\n");
            }
            TextVstup.Text = "";
            precist(path);
        }

        private void TextVstup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
