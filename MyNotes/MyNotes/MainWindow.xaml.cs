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

namespace MyNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class newNoteNameRecord
        {
            public string newNoteNameRecord_Name { get; set; }
        }

        //public class newNoteTextRecord
        //{
        //    public string newNoteTextRecord_Text { get; set; }
        //}



        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            MsgBoxNewNote.Visibility = Visibility.Visible;
            MainWindowBorder.Opacity = 0.1;
            NewNoteNameTextBox.Text = "";
        }

        private void NewNoteOkButton_Click(object sender, RoutedEventArgs e)
        {
            MsgBoxNewNote.Visibility = Visibility.Hidden;
            MainWindowBorder.Opacity = 100;
            string newNoteName = NewNoteNameTextBox.Text.ToString();
            

            try
            {
                newNoteNameRecord New_Note = new newNoteNameRecord();
                New_Note.newNoteNameRecord_Name = newNoteName;
                NotesNameDataGrid.Items.Add(New_Note);
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void NewNoteCancelButton_Click(object sender, RoutedEventArgs e)
        {
            MsgBoxNewNote.Visibility = Visibility.Hidden;
            MainWindowBorder.Opacity = 100;
        }

        private void DelNoteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DelRecord();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SaveNoteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }

            catch (Exception)
            {
                MessageBox.Show("You have not selected an item.");
            }

        }

        private void LoadNoteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

               

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void  DelRecord()
        {
            var selectedItem = NotesNameDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                NotesNameDataGrid.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item first!");
            }
            
            
        }

        private void NotesNameDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void NoteContentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string noteText = NoteContentTextBox.Text.ToString();
            
        }
    }
}
