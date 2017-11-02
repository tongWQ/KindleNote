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
using KindleNote;
//using System.Windows.Forms;

namespace KindleNoteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string notePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttontest_Click(object sender, RoutedEventArgs e)
        {
            //  notePath = @"C:\Users\Administrator\Desktop\My Clippings.txt";
            //NoteManager notes = new NoteManager(notePath);
            //string[] books = notes.GetBookNames();
            //for (int i = 0; i < books.Length; i++)
            //{
            //    if (books[i].Contains("\r\n"))
            //       books[i] = books[i].Replace("\r\n", string.Empty);
            //}
            //comboBoxBooks.ItemsSource = books;
            //comboBox.ItemsSource = notes.GetBookNames();
            try
            {
                textBoxNote.Text = string.Empty;
                NoteManager NM = new NoteManager(notePath);
                string[] toShow = NM.SearchByBook(comboBoxBooks.SelectedItem.ToString());
                for (int i = 0; i < toShow.Length; i++)
                {
                    textBoxNote.Text += "\r\n" + toShow[i] + "\r\n";
                }
            }
            catch(Exception ex)
            {
               System.Windows.MessageBox.Show(ex.Message);
            }
           // textBlockAuthor.Text = NM.GetAuthor(comboBoxBooks.Text);

        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                System.Windows.Forms.OpenFileDialog getTXT = new System.Windows.Forms.OpenFileDialog();
                getTXT.Filter = "txt File|*.txt";
                if (getTXT.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    notePath = getTXT.FileName;
                    textBoxTXTPath.Text = notePath;
                }
                NoteManager notes = new NoteManager(notePath);
                string[] books = notes.GetBookInformation();
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Contains("\r\n"))
                        books[i] = books[i].Replace("\r\n", string.Empty);
                }
                comboBoxBooks.ItemsSource = books;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);  
            }
        }

        private void comboBoxBooks_DropDownOpened(object sender, EventArgs e)
        {
            //for (int i = 0; i < comboBoxBooks.Items.Count; i++)
            //{
            //    if(comboBoxBooks.Items[i].ToString()==string.Empty)
                  
            //}
        }

        private void checkBoxDark_Checked(object sender, RoutedEventArgs e)
        {
            gridGeneral.Background = Brushes.Black;
            


            textBoxNote.Background = Brushes.Black;
            textBoxNote.Foreground = Brushes.White;

            textBoxTXTPath.Background = Brushes.Black;
            textBoxTXTPath.Foreground = Brushes.White;

            textBlockHeader.Foreground = Brushes.White;
            textBlockHeader.Background = Brushes.Black;

            checkBoxDark.Foreground = Brushes.White;
            checkBoxDark.Background = Brushes.Black;

            foreach(UIElement ui in gridGeneral.Children)
            {
                if(ui is Button)
                {
                   (ui as Button).Background = Brushes.Black;
                    (ui as Button).Foreground = Brushes.White;

                }
            }
            comboBoxBooks.Background = Brushes.Black;
          //  comboBoxBooks.Foreground = Brushes.White;
            
        }

        private void checkBoxDark_Unchecked(object sender, RoutedEventArgs e)
        {
            gridGeneral.Background = Brushes.White;



            textBoxNote.Background = Brushes.White;
            textBoxNote.Foreground = Brushes.Black;

            textBoxTXTPath.Background = Brushes.White;
            textBoxTXTPath.Foreground = Brushes.Black;

            textBlockHeader.Foreground = Brushes.Black;
            textBlockHeader.Background = Brushes.White;

            foreach (UIElement ui in gridGeneral.Children)
            {
                if (ui is Button)
                {
                    (ui as Button).Background = Brushes.White;
                    (ui as Button).Foreground = Brushes.Black;

                }
            }
            comboBoxBooks.Background = Brushes.White;
            checkBoxDark.Foreground = Brushes.Black;
            checkBoxDark.Background = Brushes.White;
        }
    }
}
