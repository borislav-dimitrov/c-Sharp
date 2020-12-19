using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Text.RegularExpressions;

namespace telephoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string sqlTbl = "dbo.phoneBook_For_C";
        

        DataTable table;
        public string connectionString;
        SqlConnection cnn;
        public string CmdString;
        public string tempMobile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // connecting to SQL DB
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

            // Filling datagrid from SQL DB
            FillDataGrid(sqlTbl, phonesDg);
        }

        public void FillDataGrid(string sqlTable, DataGrid dgrid)
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
                CmdString = $"Select * from {sqlTable}";
                SqlCommand cmd = new SqlCommand(CmdString, cnn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                table = new DataTable("table");
                sda.Fill(table);
                dgrid.ItemsSource = table.DefaultView;
                dgrid.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            CmdString = "";
            cnn.Close();

        }

        private void newBtt_Click(object sender, RoutedEventArgs e)
        {
            firstNameTb.Clear();
            lastNameTb.Clear();
            mobileTb.Clear();
            emailTb.Clear();
            categoryCb.SelectedIndex = -1;
        }

        private void insertBtt_Click(object sender, RoutedEventArgs e)
        {

            // define columns from SQL Table
            string column1 = "First";
            string column2 = "Last";
            string column3 = "Mobile";
            string column4 = "Email";
            string column5 = "Category";
            
            // define query command
            string command = $"Insert into {sqlTbl} ( {column1}, {column2}, {column3}, {column4}, {column5}) Values ('{firstNameTb.Text}', '{lastNameTb.Text}', '{mobileTb.Text}', '{emailTb.Text}', '{categoryCb.Text}');";
            //string command = $"begin If Not Exists(select * from dbo.phoneBook_for_C where {column3} = '{mobileTb.Text}')Begin insert into dbo.phoneBook_for_C ({column1}, {column2}, {column3}, {column4}, {column5}) values ('{firstNameTb.Text}', '{lastNameTb.Text}','{mobileTb.Text}', '{emailTb.Text}', '{categoryCb.Text}')End End";
            string phone = mobileTb.Text.ToString();

            if (mobileTb.Text.Length > 0)
           
                try
                {
                    // try to add the record into sql table
                    SqlCommand cmd = new SqlCommand(command, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Contact saved!");
           
                    firstNameTb.Clear();
                    lastNameTb.Clear();
                    mobileTb.Clear();
                    emailTb.Clear();
                    categoryCb.SelectedIndex = -1;
           
                    // refresh datagrid with the new record
                    FillDataGrid(sqlTbl, phonesDg);
                }
                catch (SqlException exc)
                {
                    if (exc.Number == 2627)
                    MessageBox.Show("Record with that Number already exist!");
                    cnn.Close();
                }
            //MessageBox.Show(exc.Number.ToString());
            else
            {
                MessageBox.Show("Fill phone number please!");
            }



        }

        private void phonesDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = phonesDg.Items.IndexOf(phonesDg.SelectedItem);
            string cat = table.Rows[index].ItemArray[4].ToString();
            cat = cat.Trim();

            try
            {
                string firstName = table.Rows[index].ItemArray[0].ToString();
                firstNameTb.Text = firstName.Trim();
                string lastName = table.Rows[index].ItemArray[1].ToString();
                lastNameTb.Text = lastName.Trim();
                string mobile = table.Rows[index].ItemArray[2].ToString();
                mobileTb.Text = mobile.Trim();
                string email = table.Rows[index].ItemArray[3].ToString();
                emailTb.Text = email.Trim();
                tempMobile = "";
                tempMobile = mobile.Trim();
                
                if (cat == "HOME")
                {
                    int cbselect = 0;
                    categoryCb.SelectedIndex = cbselect;
                }
                else if (cat == "OFFICE")
                {
                    int cbselect = 1;
                    categoryCb.SelectedIndex = cbselect;
                }
                else if (cat == "BUSSINESS")
                {
                    int cbselect = 2;
                    categoryCb.SelectedIndex = cbselect;
                }
                else if (cat == "FRIENDS")
                {
                    int cbselect = 3;
                    categoryCb.SelectedIndex = cbselect;
                }
                else if (cat == "FAMILY")
                {
                    int cbselect = 4;
                    categoryCb.SelectedIndex = cbselect;
                }
                else 
                {
                    int cbselect = -1;
                    categoryCb.SelectedIndex = cbselect;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void updateBtt_Click(object sender, RoutedEventArgs e)
        {
            // define columns from SQL Table
            string column1 = "First";
            string column2 = "Last";
            string column3 = "Mobile";
            string column4 = "Email";
            string column5 = "Category";



            
            try
            {
                
                if (mobileTb.Text.Length > 0)
                {
                    try
                    {

                        //try to update the record into sql table
                        string command = $"update {sqlTbl} set {column1} = '{firstNameTb.Text}', {column2} = '{lastNameTb.Text}', {column3} = '{mobileTb.Text}', {column4} = '{emailTb.Text}', {column5} = '{categoryCb.Text}' where {column3} = '{tempMobile}'";
                        cnn.Open();
                        SqlCommand cmd2 = new SqlCommand(command, cnn);                        
                        cmd2.ExecuteNonQuery();                        
                        cmd2.Dispose();
                        cnn.Close();
                        //refresh datagrid with the new record
                        FillDataGrid(sqlTbl, phonesDg);
                    }
                    catch (SqlException sqlexc)
                    {
                        if (sqlexc.Number == 2627)
                            MessageBox.Show($"Contact with number \"{mobileTb.Text.ToString()}\" already exists!");
                            cnn.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                        cnn.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Fill phone number please!");
                }
                
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                cnn.Close();
            }

        }

        private void mobileTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9+]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void mobileTb_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void deleteBtt_Click(object sender, RoutedEventArgs e)
        {
            // define columns from SQL Table
            string column1 = "First";
            string column2 = "Last";
            string column3 = "Mobile";
            string column4 = "Email";
            string column5 = "Category";

            // delete datagrid selection from SQL DB
            int index = phonesDg.Items.IndexOf(phonesDg.SelectedItem);

            // query to delte SQL row by number
            string command = $"DELETE  E FROM(SELECT  rn = ROW_NUMBER() OVER (ORDER BY (SELECT 0)) FROM {sqlTbl}) AS E where E.rn = {index + 1};";

            // query to get SQL deleted row value
            string deleted = $"Select {column3} From (Select Row_Number() Over (Order By {column3}) As RowNum , * From {sqlTbl}) t2 Where RowNum = {index + 1}";

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
                        FillDataGrid(sqlTbl, phonesDg);
                        cnn.Open();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Contact not deleted!\n" + exc.Message);
                    }

                    // actually print it to the user after deletion
                    MessageBox.Show($" Contact \"{deleted}\" is deleted!");
                    deletion.Dispose();

                    firstNameTb.Clear();
                    lastNameTb.Clear();
                    mobileTb.Clear();
                    emailTb.Clear();
                    categoryCb.SelectedIndex = -1;


                }

                else if (index == -1)
                {
                    MessageBox.Show("You have not selected any contacts!");
                    firstNameTb.Clear();
                    lastNameTb.Clear();
                    mobileTb.Clear();
                    emailTb.Clear();
                    categoryCb.SelectedIndex = -1;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            cnn.Close();



        }


    }
    
}
