using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using JsonDeser;
using Microsoft.WindowsAPICodePack.Dialogs;
using StyleElement;

namespace pr8Wpf
{

    public partial class MainWindow : Window
    {
        List<Stroka> Stroki = new List<Stroka>();
        List<Kartinki> kartinkis= new List<Kartinki>();
        string filename;
        public MainWindow()
        {
            InitializeComponent();

            var kontent = JsonDeser.JsonDeser.Deserealize<List<Stroka>>();
          
            if (kontent != null)
            {
                foreach (var k in kontent)
                {
                    string path = k.Img;
                    string content = k.text;
                    ListText.Items.Add(new Kartinki(content, path));
                    kartinkis.Add(new Kartinki(content, path));
                    Stroki.Add(k);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text != "" & filename != null)
            {
                Stroka l = new Stroka();
                l.text = Text.Text;
                l.Img = filename;
                Stroki.Add(l);
                JsonDeser.JsonDeser.Serial(Stroki);
                Kartinki element = new Kartinki(Text.Text, filename);
                ListText.Items.Add(element);
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }     
        private void Kartinka_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog= new CommonOpenFileDialog();
            CommonFileDialogResult resylt= dialog.ShowDialog();

            var result = resylt == CommonFileDialogResult.Ok ? filename = dialog.FileName : null;
            Uri uri = new Uri(filename);
            if (image != null)
            {
                image.Source = new BitmapImage(uri);
                Lable.Content = Text.Text;
            }
        }      
    }
}
