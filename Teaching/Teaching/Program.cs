using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Teaching
{
    class Program
    {
        static void Main(string[] args)
        {
            #region exceptions

            //while (true)
            //{
            //    Console.WriteLine("Input number");
            //    string x = Console.ReadLine();
            //    int y = 5;
            //
            //
            //    try
            //    {
            //        int result = Convert.ToInt32(x) + y;
            //        Console.WriteLine(result);
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine("The exception is Format Exception.");
            //
            //    }
            //
            //
            //
            //
            //}
            #endregion

            #region returnExample

            //string namePeshko = "Peshko";
            //int age = 15;
            //
            //string nameKircho = "Kircho";
            //int age2 = 20;
            //
            //
            //string story = ReturnStory(nameKircho,age2);
            //Console.WriteLine(story);
            #endregion

            #region CLassANdObj

            Koteta novoKoti = new Koteta("bqlo kote", "White");
            Koteta novoKoti2 = new Koteta("cherno kote", "Orange");


            if (novoKoti2.Cvqt == "White")
            {
                Console.WriteLine($"Koteto {novoKoti2.Name} e s bql cvqt.");
            }
            else
            {
                Console.WriteLine($"Koteto {novoKoti2.Name} e s {novoKoti2.Cvqt} cvqt.");
            }
            #endregion

            


        }

        #region returnFunction
        //static string ReturnStory(string name, int age)
        //{
        //    string asodkjapo = "";
        //    if (name == "Peshko")
        //    {
        //        asodkjapo = $"Peshko e na {age} i se kazva peshko.";
        //
        //    }
        //    else if (name == "Kircho")
        //    {
        //        asodkjapo = $"Kircho e na {age} i se kazva Kircho";
        //    }
        //    return asodkjapo;
        //}
        #endregion


    }
}
