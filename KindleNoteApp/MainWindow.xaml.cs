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
using System.Windows.Forms;

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
                textBox.Text = string.Empty;
                NoteManager NM = new NoteManager(notePath);
                string[] toShow = NM.SearchByBook(comboBoxBooks.SelectedItem.ToString());
                for (int i = 0; i < toShow.Length; i++)
                {
                    textBox.Text += "\r\n" + toShow[i] + "\r\n";
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
                OpenFileDialog getTXT = new OpenFileDialog();
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
    }
}
