using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
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
using System.Configuration;

namespace NoteApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table;
        public string connectionString;
        SqlConnection cnn;
        public string CmdString;


        public class noteAdd
        { 
            public string noteAdd_Title { get; set; }
            public string noteAdd_Content { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            //MsgBoxNewNote.Visibility = Visibility.Visible;
            //MainWindowBorder.Opacity = 0.1;
            //NewNoteNameTextBox.Text = "";
            try
            {
                NoteTitleTB.Clear();
                NoteContentTB.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        private void NewNoteOkButton_Click(object sender, RoutedEventArgs e)
        {
            MsgBoxNewNote.Visibility = Visibility.Hidden;
            MainWindowBorder.Opacity = 100;



            try
            {


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
            // delete datagrid selection from SQL DB
            int index = NotesNameDataGrid.Items.IndexOf(NotesNameDataGrid.SelectedItem);

            // query to delte SQL row by number
            string command = $"DELETE  E FROM(SELECT  rn = ROW_NUMBER() OVER (ORDER BY (SELECT 0)) FROM dbo.Notes) AS E where E.rn = {index + 1};";

            // query to get SQL deleted row value
            string deleted = $"Select Title From (Select Row_Number() Over (Order By Title) As RowNum , * From dbo.Notes) t2 Where RowNum = {index + 1}";

            try
            {
                if (index != -1)
                {
                    
                    cnn.Open();
                    // get deleted item printed to the user
                    SqlCommand del = new SqlCommand(deleted, cnn);
                    SqlDataAdapter sda = new SqlDataAdapter(del);
                    DataTable deletion = new DataTable();
                    deletion = new DataTable("Deleted");
                    sda.Fill(deletion);
                    deleted = deletion.Rows[0][0].ToString();
                    deleted = deleted.Trim();

                    // delete the item
                    SqlCommand cmd = new SqlCommand(command, cnn);
                    cmd.ExecuteNonQuery();

                    // refresh the table
                    try
                    {
                        cnn.Close();
                        FillDataGrid();
                        cnn.Open();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Note not deleted!\n" + exc.Message);
                    }

                    // actually print it to the user after deletion
                    MessageBox.Show($" Note \"{deleted}\" is deleted!");
                    deletion.Dispose();

                    NoteContentTB.Clear();
                    NoteTitleTB.Clear();

                    
                }

                else if (index == -1)
                {
                    MessageBox.Show("You have not selected any notes!");
                    NoteContentTB.Clear();
                    NoteTitleTB.Clear();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            cnn.Close();



        }

        private void SaveNoteButton_Click(object sender, RoutedEventArgs e)
        {
            string table = "dbo.Notes";
            string columnTitle = "Title";
            string columnContext = "Context";
            string command = $"Insert into {table} ( {columnTitle}, {columnContext}) Values ('{NoteTitleTB.Text}', '{NoteContentTB.Text}');";
            
            try
            {
                if (NoteTitleTB.Text.Length > 0)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(command, cnn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note saved!");
                }
                else
                {
                    MessageBox.Show("Please input Title !!");
                }

                NoteTitleTB.Clear();
                NoteContentTB.Clear();
                cnn.Close();

            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

           try
           {
               FillDataGrid();
           }
           catch (Exception exc)
           {
               MessageBox.Show("Note not saved !\n" + exc.Message);
           }

        }

        private void EditNoteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = NotesNameDataGrid.Items.IndexOf(NotesNameDataGrid.SelectedItem);
            
            
            try
            {
                if (index > -1)
                {
                    NoteTitleTB.Text = table.Rows[index].ItemArray[0].ToString();
                    NoteContentTB.Text = table.Rows[index].ItemArray[1].ToString();
                }


                else if (index == -1)
                {
                    MessageBox.Show("You have not selected any notes!");
                }
                        
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void NotesNameDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NoteContentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // connecting to SQL DB with connection string from app.config file
            
            connectionString = ConfigurationManager.ConnectionStrings["C# testings"].ConnectionString;
            CmdString = string.Empty;
            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Couldnt establish connection to SQL Server!\n" + exc.Message);
            }
            cnn.Close();


            // creating datagrid from SQL DB
            FillDataGrid();
            
            



        }

        // function for building datagrid from SQL DB
        public void FillDataGrid()
        {
            try
            {
                cnn.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Couldnt establish connection to SQL Server!\n" + exc.Message);
            }

            try
            {
                CmdString = "Select Title,Context from dbo.Notes";
                SqlCommand cmd = new SqlCommand(CmdString, cnn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                table = new DataTable("Notes");
                sda.Fill(table);
                NotesNameDataGrid.ItemsSource = table.DefaultView;
                NotesNameDataGrid.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                NotesNameDataGrid.Columns[1].Visibility = Visibility.Hidden;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            CmdString = "";
            cnn.Close();

        }


    }

}

