using System;
using System.Collections.Generic;
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

namespace HomeWork3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ss(ref String s1, ref String s2)
        {
            s1 = s1.Trim();
            s2 = s2.Trim();
            while (s2.Length < s1.Length)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    s2 = s2 + s2[i];
                    if (s2.Length == s1.Length)
                        break;
                }
            }
        }

        public String Alphabeta(String s1)
        {
            string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            string LatinAlphabet = "abcdefghijklmnopqrstuvwxyz";

            string s5 = s1.ToUpper();
            if ((Byte)s5[0] < 65)
                return RusAlphabet;
            else
                return LatinAlphabet;
        }

        public String conduct(String s1, String s2, String Alpha)
        {
            String result = "";
            int a, b;
            Char c;
            Char h;
            String Alphabet;
            if (s1.Length == s2.Length)
            {
                int k = 0;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (i < (s1.Length - 1))
                        h = s1[i + 1];
                    else
                        h = ' ';

                    if (Alpha.IndexOf(s1[i]) != -1)
                        Alphabet = Alpha.ToLower();
                    else Alphabet = Alpha.ToUpper();

                    a = Alphabet.IndexOf(s1[i]);
                    if (a != -1)
                    {
                        b = Alpha.IndexOf(s2[k]);
                        c = Alphabet[((a + b) % (Alphabet.Length))];
                        result = (String)(result + c);
                        k++;
                    }
                    else if (s1[i] != h)
                        result = result + s1[i];
                }
            }

            if (s1.Length < s2.Length)
            {
                String ss = String.Concat(s1, s2.Replace(" ", ""));
                int d = 0;
                for (int i = 0; i < s2.Length; i++)
                {
                    if ((s2[i] != ' ') || (s2[i] == ',') || (s2[i] == '.'))
                    {
                        result = result + ss[d];
                        d = d + 1;
                    }
                    else
                        result += s2[i];
                }
            }
            return result;
        }

        private void Encryption_Click(object sender, RoutedEventArgs e)
        {
            String Alphabet;

            String s1 = Input1.Text;
            String s2 = Input2.Text;
            s2 = s2.ToLower();

            ss(ref s1, ref s2);

            Alphabet = Alphabeta(s1);

            Output.Text = $"{conduct(s1, s2, Alphabet)}";
        }

        private void Decrytion_Click(object sender1, RoutedEventArgs e1)
        {
            String Alphabe;

            String s3 = Input1.Text;
            String s4 = Input2.Text;
            s4 = s4.ToLower();

            ss(ref s3, ref s4);
            String Alpha = Alphabeta(s3);

            String result = "";
            int a, b;
            Char c;
            int d;
            Char h;

            if (s3.Length == s4.Length)
            {
                int k = 0;
                for (int i = 0; i < s3.Length; i++)
                {

                    if (i == (s3.Length - 1))
                        h = ' ';
                    else h = s3[i + 1];

                    if (Alpha.IndexOf(s3[i]) != -1)
                        Alphabe = Alpha.ToLower();
                    else Alphabe = Alpha.ToUpper();
                    a = Alphabe.IndexOf(s3[i]);
                    if (a != -1)
                    {
                        b = Alpha.IndexOf(s4[k]);
                        d = (a - b);
                        if (d >= 0)
                        {
                            c = Alphabe[d];
                        }
                        else
                        {
                            d = d + Alphabe.Length;
                            c = Alphabe[d];
                        }

                        result = (String)(result + c);
                        k++;
                    }
                    else if (s3[i] != h)
                        result = result + s3[i];
                }
            }

            Output.Text = $"{result}";
        }
    }
}
