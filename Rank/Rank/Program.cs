using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rang game");
            var test = Rank();
            Console.WriteLine();
            Console.WriteLine($"Your simbol rank is {test}");
            Console.ReadKey();
        }
        static int Rank ()
        {
            string numAndBracket = ReadString("string with numbers, '(' and ')' ");
            char num = CharRead("simbol");
            int rank = 0;
            for(int i = 0; i < numAndBracket.Length; i++)
            {
                    if (numAndBracket[i] == '(')
                    {
                        rank++;
                    }
                    else if (numAndBracket[i] == ')')
                    {
                        rank--;
                    }
                    else if (numAndBracket[i] == num)
                    {
                        break;
                    }
            }
            return rank;
        }
        static string ReadString(string readString)
        {
            Console.WriteLine($"Enter {readString}");
            string line = "";
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }
                else if (key.KeyChar > 47 && key.KeyChar < 58 || key.KeyChar == '(' || key.KeyChar == ')')
                {
                    line += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return line;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bet input {readString}, try again or click escape");
                    line = "";
                    continue;
                }
            }
        }
        static char CharRead (string readChar)
        {
            Console.WriteLine($"Enter {readChar}");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }
                else if (key.KeyChar > 47 && key.KeyChar < 58)
                {
                    return key.KeyChar;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bet input {readChar}, try again or click escape");
                    continue;
                }
            }
        }
    }
}
