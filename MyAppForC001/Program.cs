using System;
using System.Collections.Generic;

namespace MyAppForC01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(AddBinary(44));

              static int AddBinary(int n)
            {
                // your code ...
                int howManyTimes = 0;
                List<int> storeNumbers = new List<int>();
                newNum:
                
                
                string nToString = Convert.ToString(n);
                int nLength = nToString.Length;
                int counter = 0;
                int result = 1;
                
                while (counter < nLength)
                {
                    char separate = nToString[counter];
                    int getNumber = (int)Char.GetNumericValue(separate);
                    storeNumbers.Add(getNumber);
                    counter++;
                }
                
                for (int i = 0; i < storeNumbers.Count; i++)
                {
                    result = result * storeNumbers[i];
                    
                }
               
                howManyTimes++;
                if (result.ToString().Length <= 1)
                {
                    goto End;
                }
                else
                {
                    n = result;
                    storeNumbers.Clear();
                    goto newNum;
                }
            End:
                return howManyTimes;
            }
        }
    }
}
