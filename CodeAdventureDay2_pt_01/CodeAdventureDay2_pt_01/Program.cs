using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeAdventureDay2_pt_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>();
            List<string> lines = new List<string>();
            
            string file = @"C:\Users\user\source\repos\CodeAdventureDay2_pt_01\CodeAdventureDay2_pt_01\bin\Debug\puzzle.txt";
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
            int counter = 0;
            int valid = 0;

            try
            {
                while (counter <= count)
                {
                    //Console.WriteLine(lines[counter]);


                    string getLine = lines[counter].ToString();
                    string[] split = getLine.Split(' ');
                    //getNumbers.ToString();
                    //Console.WriteLine(getNumbers[0]);

                    string[] getNumbers = split[0].Split('-');
                    string getMin = getNumbers[0];
                    int getMin1 = Convert.ToInt32(getMin);
                    string getMax = getNumbers[1];
                    int getMax1 = Convert.ToInt32(getMax);
                    

                    string[] getLetter = split[1].Split(':');
                    string pwdLetter = getLetter[0];
                    //Console.WriteLine(pwdLetter);

                    string pwdString = split[2];
                    //Console.WriteLine(pwdString);

                    //int test = Regex.Matches(pwdString, pwdLetter).Count;


                    //if (test >= getMin1 || testc <= getMax1)
                    //{
                    //    Console.WriteLine("Valid!");
                    //    valid++;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invlid!");
                    //}

                    getMin1 = getMin1 - 1;
                    getMax1 = getMax1 - 1;


                    if (pwdString.IndexOf(pwdLetter, getMin1 , pwdLetter.Length) == getMin1  && pwdString.IndexOf(pwdLetter, getMax1, pwdLetter.Length) == getMax1)
                    {
                        Console.WriteLine("Invalid");
                    }
                    else if (pwdString.IndexOf(pwdLetter,getMin1,pwdLetter.Length) == getMin1 || pwdString.IndexOf(pwdLetter, getMax1, pwdLetter.Length) == getMax1)
                    {
                        Console.WriteLine(pwdLetter + " in " + pwdString + " at position " + getMin1);
                        valid++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }


                    if (counter == count)
                        goto End;

                    counter++;
                }
            }
            catch (Exception exc)
            {
                //Console.WriteLine(exc.Message);
            }


        End:
            Console.WriteLine("\n\n End..");
            Console.WriteLine("Valid pwds: " + valid);

            



        }
    }
}
