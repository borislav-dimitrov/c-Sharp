using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilutoLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            AsciiToStr();
        }

        static void AsciiToStr()
        {
            int unicode = 100;
            char character = (char)unicode;
            //string text = character.ToString();
            Console.WriteLine(character.ToString() + character.ToString());
        }
    }
}
