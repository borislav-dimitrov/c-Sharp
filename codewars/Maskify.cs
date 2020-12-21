using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppForC01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(maskify("my name is george and i am rich!"));
            
            static string maskify(string n)
            {
                int getLength = n.Length;
                var aStringBuilder = new StringBuilder(n);

                if (getLength >= 5)
                {
                    string replaceWith = new string('#', getLength - 4);

                    aStringBuilder.Remove(0, getLength - 4);
                    aStringBuilder.Insert(0, replaceWith);
                    n = aStringBuilder.ToString();                            
                    
                }
                else
                {
                    goto End;
                }
                End:
                return n;

            }
        }
    }
}
