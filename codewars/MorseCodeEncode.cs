using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppForC01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(charToMorse('b'));
            Console.WriteLine(wordToMorse("ben ten"));
            
            static string wordToMorse(string str)
            {
                str = str.ToUpper();
                List<string> finalString = new List<string>();
                string convertedWord = ""; 
                int getLength = str.Length;
                int counter = 0;
                while (counter < getLength)
                    {
                        
                        if (str[counter] == ' ')
                        {
                            finalString.Add("  ");
                        }
                        else
                        {
                            finalString.Add(Convert.ToString(charToMorse(str[counter])));
                            
                        }
                    counter++;
                    }
                counter = 0;
                convertedWord = string.Join(" ", finalString);
                return convertedWord ;
            }

            static string charToMorse(char n)
            {
                string newN = "";
                if (n == 'A')
                    newN = ".-";                  
                else if (n == 'B')
                    newN = "-...";
                else if (n == 'C' )
                    newN = "-.-.";
                else if (n == 'D')
                    newN = "-..";
                else if (n == 'E')
                    newN = ".";
                else if (n == 'F')
                    newN = "..-.";
                else if (n == 'G')
                    newN = "--.";
                else if (n == 'H')
                    newN = "....";
                else if (n == 'I')
                    newN = "..";
                else if (n == 'J')
                    newN = ".---";
                else if (n == 'K' )
                    newN = "-.-";
                else if (n == 'L')
                    newN =".-..";
                else if (n == 'M')
                    newN = "--";
                else if (n == 'N')
                    newN = "-.";
                else if (n == 'O')
                    newN = "---";
                else if (n == 'P')
                    newN = ".--.";
                else if (n == 'Q')
                    newN = "--.-";
                else if (n == 'S')
                    newN = "...";
                else if (n == 'T')
                    newN = "-";
                else if (n == 'U')
                    newN = "..-";
                else if (n == 'V')
                    newN = "...-";
                else if (n == 'W')
                    newN = ".--";
                else if (n == 'X')
                    newN = "-..-";
                else if (n == 'Y')
                    newN = "-.--";
                else if (n == 'Z')
                    newN = "--..";
                else if (n == '1')
                    newN = ".----";
                else if (n == '2')
                    newN = "..---";
                else if (n == '3')
                    newN = "...--";
                else if (n == '4')
                    newN = "....-";
                else if (n == '5')
                    newN = ".....";
                else if (n == '6')
                    newN = "-....";
                else if (n == '7')
                    newN = "--...";
                else if (n == '8')
                    newN = "---..";
                else if (n == '9')
                    newN = "----.";
                else if (n == '0')
                    newN = "-----";
                return newN;
            }

        }
    }
}
