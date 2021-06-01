using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppForC01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(morse(".... . -.--   .--- ..- -.. ."));
            
            static string morse(string morseCode)
            {
                List<string> finalWord = new List<string>();
                string theActualWord = ""; 
                string[] splitted = morseCode.Split(' ');
                int counter = 0;
                foreach (string item in splitted )
                    {
                        if (splitted[counter] == "" && splitted[counter+1] == "")
                            {
                                finalWord.Add(" ");
                            }
                        else
                        {   if (splitted[counter].Length != 0)
                                {
                                    finalWord.Add(reverseMorse(splitted[counter]));
                                    //Console.WriteLine(reverseMorse(splitted[counter]));
                                }
                        }
                       
                       counter++;
                    }
                counter = 0;
                theActualWord = string.Join("", finalWord);
                return theActualWord ;
            }

            static string reverseMorse(string n)
            {
                char newN = ' ';
                if (n == ".-")
                    newN = 'A';                  
                else if (n == "-...")
                    newN = 'B';
                else if (n == "-.-." )
                    newN = 'C';
                else if (n == "-..")
                    newN = 'D';
                else if (n == ".")
                    newN = 'E';
                else if (n == "..-.")
                    newN = 'F';
                else if (n == "--.")
                    newN = 'G';
                else if (n == "....")
                    newN = 'H';
                else if (n == "..")
                    newN = 'I';
                else if (n == ".---")
                    newN = 'J';
                else if (n == "-.-")
                    newN = 'K';
                else if (n == ".-..")
                    newN = 'L';
                else if (n == "--")
                    newN = 'M';
                else if (n == "-.")
                    newN = 'N';
                else if (n == "---")
                    newN = 'O';
                else if (n == ".--.")
                    newN = 'P';
                else if (n == "--.-")
                    newN = 'Q';
                else if (n == "...")
                    newN = 'S';
                else if (n == "-")
                    newN = 'T';
                else if (n == "..-")
                    newN = 'U';
                else if (n == "...-")
                    newN = 'V';
                else if (n == ".--")
                    newN = 'W';
                else if (n == "-..-")
                    newN = 'X';
                else if (n == "-.--")
                    newN = 'Y';
                else if (n == "--..")
                    newN = 'Z';
                else if (n == ".----")
                    newN = '1';
                else if (n == "..---")
                    newN = '2';
                else if (n == "...--")
                    newN = '3';
                else if (n == "....-")
                    newN = '4';
                else if (n == ".....")
                    newN = '5';
                else if (n == "-....")
                    newN = '6';
                else if (n == "--...")
                    newN = '7';
                else if (n == "---..")
                    newN = '8';
                else if (n == "----.")
                    newN = '9';
                else if (n == "-----")
                    newN = '0';
                return newN.ToString();
            }

        }
    }
}
