using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class ChessPiece
    {
        public string Name { get; set; }

        public ChessPiece(string name)
        {
            Name = name;
        }
    }
}
