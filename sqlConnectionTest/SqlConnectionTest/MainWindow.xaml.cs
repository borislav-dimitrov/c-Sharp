using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
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

namespace SqlConnectionTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connetionString;
        public SqlConnection cnn;
        public SqlCommand command;
        public SqlDataReader dataReader;
        public string sql, Output = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectBttn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            { 
            connetionString = @"Server=.\TestSQL_Server; Database=C# testings; Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void DisconnectBttn_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            cnn.Close();
            MessageBox.Show("Connection Closed !");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SelectBttn_Click(object sender, RoutedEventArgs e)
        {
            
            sql = "Select * from dbo.Notes";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
                }
                MessageBox.Show(Output);
                dataReader.Close();
                command.Dispose();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }
}
