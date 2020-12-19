using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay01_pt02
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();
            List<string> lines = new List<string>();


            try
            {
                StreamReader reader = new StreamReader(@"C:\Users\user\source\repos\CodeAdventureDay1\CodeAdventureDay1\bin\Debug\nums.txt");



                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        int number;
                        if (int.TryParse(reader.ReadLine(), out number) && number != 0)
                        {
                            numbers.Add(number);
                            //Console.WriteLine(number);
                        }

                    }
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            int count = numbers.Count();
            //Console.WriteLine(count);
            int result = 0;
            int excpected = 2020;
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;

            try
            {
                while (counter1 <= count)
                {

                    while (counter2 <= count)
                    {

                        while (counter3 <= count)

                        {
                            try
                            {
                                int x = 0;
                                int y = 0;
                                int z = 0;

                                result = 0;
                                result = numbers[counter1] + numbers[counter2] + numbers[counter3];

                                x = numbers[counter1];
                                y = numbers[counter2];
                                z = numbers[counter3];

                                if (result.Equals(excpected))
                                {
                                    Console.WriteLine(numbers[counter1].ToString() + " + " + numbers[counter2].ToString() + " + " + numbers[counter3].ToString() + " = 2020!");
                                    goto STOP;
                                }


                            }
                            catch (Exception ex)
                            {
                                //Console.WriteLine(ex.Message);
                            }
                            
                            counter3++;

                            if (counter3 == count)
                            {
                                counter3 = 0;
                                counter2++;
                            }
                            else if (counter2 == count)
                            {
                                counter2 = 0;
                                counter1++;
                            }
                            
                            else if (counter1 == count)
                            {
                                
                                goto STOP;
                            }
                        }
                    }
                    if(counter1 == count)
                    {
                        Console.WriteLine(numbers[counter1].ToString() + " + " + numbers[counter2].ToString() + " + " + numbers[counter3].ToString() + " = 2020!");
                        goto STOP;
                    }
                STOP:
                    Console.WriteLine("Stop!");
                    break;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
