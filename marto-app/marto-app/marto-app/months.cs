using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marto_app
{
    public class Months
    {
        public int x { get; set; }
        public int y { get; set; }
        public string name { get; set; }

        public Months(string namE, int xx, int yy)
        {
            name = namE;
            x = xx;
            y = yy;
        }

    }
    
}
