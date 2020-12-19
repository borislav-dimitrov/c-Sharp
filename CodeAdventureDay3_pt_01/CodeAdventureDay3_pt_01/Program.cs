using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdventureDay3_pt_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>();
            List<string> lines = new List<string>();

            string file = @"C:\Users\user\source\repos\CodeAdventureDay3_pt_01\CodeAdventureDay3_pt_01\bin\Debug\new_puzzle.txt";
            try
            {
                StreamReader reader = new StreamReader(file);

                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        lines.Add(line);
                        //Console.WriteLine(line);
                    }
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            int count = lines.Count;
            var xS = 0;
            var oS = 0;
            int counter = 1;
            int charPos = 7;


            /*
            //fill the file
            try
            {
                StreamWriter streamWriter = new StreamWriter("new_puzzle.txt");
                using (streamWriter)
                {
                    while (counter <= count)
                    {
                        streamWriter.WriteLine(lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter]
                             + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter] + lines[counter]);
                        counter++;
                    }
            
                }
            }
            catch (Exception exc)
            {
                //Console.WriteLine(exc.Message);
            } //*/

            //*
            Console.WriteLine(0 + " row");
            while (counter <= count)
            {
                try
                {
            
                    //counter++;
                    //Console.WriteLine(lines[counter]);
                    string lineToString = lines[counter].ToString();
                    //Console.WriteLine(lineToString);
            
            
            

            
                    
                    StringBuilder sb = new StringBuilder(lineToString);
            
            
            
                    char defXorO = lineToString[charPos];
                    if (defXorO == '#')
                    {
                        xS++;
                        sb[charPos] = 'X';
                        lineToString = sb.ToString();
                        //Console.WriteLine(lineToString);
                        Console.WriteLine(counter + " row " + defXorO );
                    }
                    else if (defXorO == '.')
                    {
                        oS++;
                        sb[charPos] = 'O';
                        lineToString = sb.ToString();
                        //Console.WriteLine(lineToString);
                        Console.WriteLine(counter + " row " + defXorO);
                    }
                    else
                    {
            
                    }
                    counter++;
                    charPos = charPos + 7;
                    //charPos++;
            
            
            
                    if (counter == count + 2)
                        goto End;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    goto End;
                }
            
            
            }
        End:
            Console.WriteLine("\n\n Ending...");
            Console.WriteLine("Trees hit \"xS\" = " + xS);
            Console.WriteLine("Trees not hit \"oS\" = " + oS + "\n\n"); //*/
        }
    }
}
