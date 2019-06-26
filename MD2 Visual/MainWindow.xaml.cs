using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;

namespace MD2_Visual
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string text = textbox1.Text;
            string result;

            //md2
            MD2 md2 = new MD2(text);

            result = md2.GetHash();

            textbox2.Text = result;

            //sha1
            byte[] hash;

            using (var sha1 = new SHA1CryptoServiceProvider())
                hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));

            var sb = new StringBuilder();

            foreach (byte b in hash)
                sb.AppendFormat("{0:x2}", b);

            textbox3.Text = sb.ToString();



        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Clear();
            textbox2.Clear();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
       }
    }
}
