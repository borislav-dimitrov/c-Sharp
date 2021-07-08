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


namespace marto_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Months> allMonths = new List<Months>();
        public List<dDays> allDays = new List<dDays>();
        public List<figures> allFigures = new List<figures>();
        public List<Label> allLabels = new List<Label>();
        //public Months Months2;

        public MainWindow()
        {
            InitializeComponent();
            main();
        }

        #region get all labels

        private void getAllLabels()
        {
            try
            {
                foreach (var label in myGrid.Children)
                {
                    string defineType = label.GetType().ToString();
                    if (defineType.ToLower().Equals("system.windows.controls.label"))
                    {
                        allLabels.Add(label as Label);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region create months

        private void createMtnhs()
        {
            Months jan = new Months("jan", 1, 1);
            Months feb = new Months("feb", 2, 1);
            Months mar = new Months("mar", 3, 1);
            Months apr = new Months("apr", 4, 1);
            Months may = new Months("may", 5, 1);
            Months jun = new Months("jun", 6, 1);

            Months jul = new Months("jul", 1, 2);
            Months aug = new Months("aug", 2, 2);
            Months sep = new Months("sep", 3, 2);
            Months oct = new Months("oct", 4, 2);
            Months nov = new Months("nov", 5, 2);
            Months dec = new Months("dec", 6, 2);


           allMonths.Add(jan);
           allMonths.Add(feb);
           allMonths.Add(mar);
           allMonths.Add(apr);
           allMonths.Add(may);
           allMonths.Add(jun);
           allMonths.Add(jul);
           allMonths.Add(aug);
           allMonths.Add(sep);
           allMonths.Add(oct);
           allMonths.Add(nov);
           allMonths.Add(dec);
        }

        #endregion

        #region create days

        private void createDays()
        {
            dDays one = new dDays(1, 1, 3);
            dDays two = new dDays(2, 2, 3);
            dDays three = new dDays(3, 3, 3);
            dDays four = new dDays(4, 4, 3);
            dDays five = new dDays(5, 5, 3);
            dDays six = new dDays(6, 6, 3);
            dDays seven = new dDays(7, 7, 3);
            dDays eight = new dDays(8, 1, 4);
            dDays nine = new dDays(9, 2, 4);
            dDays ten = new dDays(10, 3, 4);
            dDays eleven = new dDays(11, 4, 4);
            dDays twelve = new dDays(12, 5, 4);
            dDays thirteen = new dDays(13, 6, 4);
            dDays fourteen = new dDays(14, 7, 4);
            dDays fifteen = new dDays(15, 1, 5);
            dDays sixteen = new dDays(16, 2, 5);
            dDays seventeen = new dDays(17, 3, 5);
            dDays eighteen = new dDays(18, 4, 5);
            dDays nineteen = new dDays(19, 5, 5);
            dDays twenty = new dDays(20, 6, 5);
            dDays twentyone = new dDays(21, 7, 5);
            dDays twentytwo = new dDays(22, 1, 6);
            dDays twentythree = new dDays(23, 2, 6);
            dDays twentyfour = new dDays(24, 3, 6);
            dDays twentyfive = new dDays(25, 4, 6);
            dDays twentysix = new dDays(26, 5, 6);
            dDays twentyseven = new dDays(27, 6, 6);
            dDays twentyeight = new dDays(28, 7, 6);
            dDays twentynine = new dDays(29, 1, 7);
            dDays thirty = new dDays(30, 2, 7);
            dDays thirtyone = new dDays(31, 3, 7);

            allDays.Add(one);
            allDays.Add(two);
            allDays.Add(three);
            allDays.Add(four);
            allDays.Add(five);
            allDays.Add(six);
            allDays.Add(seven);
            allDays.Add(eight);
            allDays.Add(nine);
            allDays.Add(ten);
            allDays.Add(eleven);
            allDays.Add(twelve);
            allDays.Add(thirteen);
            allDays.Add(fourteen);
            allDays.Add(fifteen);
            allDays.Add(sixteen);
            allDays.Add(seventeen);
            allDays.Add(eighteen);
            allDays.Add(nineteen);
            allDays.Add(twenty);
            allDays.Add(twentyone);
            allDays.Add(twentytwo);
            allDays.Add(twentythree);
            allDays.Add(twentyfour);
            allDays.Add(twentyfive);
            allDays.Add(twentysix);
            allDays.Add(twentyseven);
            allDays.Add(twentyeight);
            allDays.Add(twentynine);
            allDays.Add(thirty);
            allDays.Add(thirtyone);
        }

        #endregion

        #region create figures

        private void createFigures()
        {
            figures figure1a = new figures("figure1a", new SolidColorBrush(Colors.Red), 5);

            //figure1a.buildFigure1a(x1y1Lbl, figure1a, allLabels);

            allFigures.Add(figure1a);
        }

        #endregion

        #region created objects check

        private void createdObjctsCheck(string obj)
        {
            if (obj == "months")
            {
                foreach (Months month in allMonths)
                {
                    obj += month.name.ToString() + "     x-" + month.x.ToString() + " y-" + month.y.ToString() + Environment.NewLine;
                }
                MessageBox.Show(obj);
            }
            else if (obj == "days")
            {
                foreach (dDays day in allDays)
                {
                    obj += day.name.ToString() + "     x-" + day.x.ToString() + " y-" + day.y.ToString() + Environment.NewLine;
                }
                MessageBox.Show(obj);
            }
            else if (obj == "labels")
            {
                foreach (Label label in allLabels)
                {
                    obj += label.Name.ToString() + Environment.NewLine;
                }
                MessageBox.Show(obj);
            }
            else
            {
                MessageBox.Show("Not a valid obj");
            }
        }

        #endregion

        private void main()
        {
            getAllLabels();
            
            createMtnhs();
            createDays();

            markAllItems();

            
            
            //createdObjctsCheck("labels");
            //markOneItem(allMonths[0].x,allMonths[0].y);
            
        }

        #region markItem

        private void markOneItem(int x, int y, SolidColorBrush bg)
        {
            //x1y1Lbl
            string lblToSelName = 'x' + x.ToString() + 'y' + y.ToString() + "Lbl";

            foreach (Label lbl in allLabels)
            {
                if (lbl.Name == lblToSelName)
                {
                    lbl.Background = bg;
                }
            }
        }

        private void markAllItems()
        {
            foreach(Months month in allMonths)
            {
                markOneItem(month.x,month.y, month.bg);
            }

            foreach(dDays day in allDays)
            {
                markOneItem(day.x, day.y, day.bg);
            }
        }



        #endregion

        private void magicBtn_Click(object sender, RoutedEventArgs e)
        {
            createFigures();
            calcAllPossiblePositiones();
        }

        private void calcAllPossiblePositiones()
        {
            string allValidPosStartPnt = "";

            foreach(Label label in allLabels)
            {
                allFigures[0].buildFigure1a(label, allFigures[0], allLabels, true);
                markAllItems();
            }
            
            foreach(string str in allFigures[0].validPosStartPnt)
            {
                allValidPosStartPnt += str + "  ;";
            }

            foreach(string str in allFigures[0].validPosStartPnt)
            {
                foreach(Label lbl in allLabels)
                {
                    if(str.ToString() == lbl.Name.ToString())
                    {
                        lbl.Background = allFigures[0].bg;
                    }
                }
            }
            MessageBox.Show("Total valid: " + allFigures[0].validPositions.ToString() + Environment.NewLine + "All valid start points: " + allValidPosStartPnt);
        }
    }
}
