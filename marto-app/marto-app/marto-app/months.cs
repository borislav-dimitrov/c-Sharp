using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace marto_app
{
    public class Months
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }
        public SolidColorBrush bg = new SolidColorBrush(Colors.LightBlue);

        public Months(string namE, int xx, int yy)
        {
            name = namE;
            x = xx;
            y = yy;

            
        }

    }
    
}
