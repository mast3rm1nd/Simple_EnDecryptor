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

namespace Simple_EnDecryptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string letters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Encrypt_Click(object sender, RoutedEventArgs e)
        {
            var text = TextBox_Plain.Text.ToLower();
            var crypted = "";

            foreach(char ch in text)
            {
                if(letters.Contains(ch))
                    crypted += string.Format("{0:D2} ", letters.IndexOf(ch) + 1);
            }

            TextBox_Encrypted.Text = crypted;
        }

        private void Button_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var plain = "";

            foreach(char ch in TextBox_Encrypted.Text)
            {
                if(ch == ' ' || ch == '\n' || ch == '\r')
                    continue;

                if(ch < '0' || ch > '9')
                {
                    TextBox_Plain.Text = "В шифре допустимы только числа, вида NM (где N и M - цифры), NM может быть от 01 до 33, пробелы и знаки переноса. Числа должны быть разделены пробелом.";
                    return;
                }
            }

            var is_digits = TextBox_Encrypted.Text.Trim().Split(' ');

            foreach(string is_digit in is_digits)
            {
                var digit = 0;
                if (!int.TryParse(is_digit, out digit) || digit > 33 || digit <= 0 || is_digit == "")
                {
                    TextBox_Plain.Text = "В шифре допустимы только числа от 1 до 33, пробелы и знаки переноса. Числа должны быть разделены пробелом.";
                    return;
                }                    
            }

            foreach(string number in is_digits)
            {
                var num = int.Parse(number);

                plain += letters[num - 1];
            }


            TextBox_Plain.Text = plain;
        }
    }
}
