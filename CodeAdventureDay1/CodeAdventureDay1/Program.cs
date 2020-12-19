using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdventureDay1
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
                        while(!reader.EndOfStream)
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
            Console.WriteLine(count);
            int counter = 0;
            int result = 0;
            int i = 0;

            try
            {
                while (counter <= 200)
                {

                    while (i <= 200)
                    {
                        result = numbers[counter] + numbers[i];



                        if (result != 2020)
                        {
                            i++;
                        }
                        else
                        {
                            Console.WriteLine(numbers[counter].ToString() + "+" + numbers[i].ToString() + "is equal to 2020.");
                           
                            break;
                        }


                        if (result == 2020)
                        {
                            break;
                        }
                        else if (i == 200)
                        {
                            i = 0;
                            counter++;
                        }
                        
                    }
                    

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }


    }
}
