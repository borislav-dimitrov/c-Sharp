using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace marto_app
{
    public class dDays
    {
        public int x { get; set; }
        public int y { get; set; }
        public int name { get; set; }
        public SolidColorBrush bg = new SolidColorBrush(Colors.Tan);


        public dDays(int namE, int xx, int yy)
        {
            x = xx;
            y = yy;
            name = namE;

            if (x == 6 || x == 7)
            {
                bg = new SolidColorBrush(Colors.LightCoral);
            }
        }
    }
}
