using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
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

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.CheckBoxWeld.IsChecked = this.CheckBoxAssembly.IsChecked = this.CheckBoxPlasma.IsChecked = this.CheckBoxLaser.IsChecked = this.CheckBoxPurchase.IsChecked =
                this.CheckBoxLathe.IsChecked = this.CheckBoxDrill.IsChecked = this.CheckBoxFold.IsChecked = this.CheckBoxRoll.IsChecked = this.CheckBoxSaw.IsChecked = false;

        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            this.Length_TextBox.Text += ((CheckBox)sender).Content + " ";

        }

        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Length_TextBox.Text = "";
            if (CheckBoxWeld.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxWeld.Content + " ";
            }
            if (CheckBoxAssembly.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxAssembly.Content + " ";
            }
            if (CheckBoxPlasma.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxPlasma.Content + " ";
            }
            if (CheckBoxLaser.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxLaser.Content + " ";
            }
            if (CheckBoxPurchase.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxPurchase.Content + " ";
            }
            if (CheckBoxLathe.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxLathe.Content + " ";
            }
            if (CheckBoxDrill.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxDrill.Content + " ";
            }
            if (CheckBoxFold.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxFold.Content + " ";
            }
            if (CheckBoxRoll.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxRoll.Content + " ";
            }
            if (CheckBoxSaw.IsChecked == true)
            {
                Length_TextBox.Text += CheckBoxSaw.Content + " ";
            }

        }

        private void Finish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Note_TextBox == null)
                return;

            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;

            this.Note_TextBox.Text = (string)value.Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Finish_SelectionChanged(this.Finish_ComboBox, null);
        }


        private void Supplier_Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mass_TextBox.Text = Supplier_Name_TextBox.Text;
        }
    }
}
