using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rank
{
    class Program
    {
        const int first = 47;
        const int end = 58;
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
            char num = CharRead("your simbol");
            Console.WriteLine();
            char numInString = CharRead("number your simbol in string");
            int rank = 0;
            var havingNum = false;
            while (true)
            {
                for (int i = 0; i < numAndBracket.Length; i++)
                {
                    if (numAndBracket[i] == '(')
                    {
                        rank++;
                    }
                    else if (numAndBracket[i] == ')')
                    {
                        rank--;
                    }
                    if (numAndBracket[i] == num && numInString != first + 2)
                    {
                        numInString--;
                        continue;
                    }
                    else if (numAndBracket[i] == num && numInString == first + 2)
                    {
                        havingNum = true;
                        break;
                    }
                }
                if (havingNum == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Don`t have your simbol in string");
                    num = CharRead("your new simbol or click escape");
                    Console.WriteLine();
                    numInString = CharRead("number your new simbol in string or click escape");
                    continue;
                }
                else
                {
                    return rank;
                }
            }
        }
        static string ReadString(string readString)
        {
            Console.WriteLine($"Enter {readString}");
            string line = "";
            var leftBracket = 0;
            var rightBracket = 0;
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    line = line.Remove(line.Length-1);
                }
                else if (key.KeyChar > first && key.KeyChar < end)
                {
                    line += key.KeyChar;
                }
                else if (key.KeyChar == '(')
                {
                    leftBracket++;
                    line += key.KeyChar;
                }
                else if (key.KeyChar == ')')
                {
                    rightBracket++;
                    line += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (leftBracket == rightBracket)
                    {
                        Console.WriteLine();
                        return line;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Bet input '(' != ')', try again or click escape");
                        line = "";
                        leftBracket = 0;
                        rightBracket = 0;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bet input {key.KeyChar}, try again or click escape");
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
                else if (key.KeyChar > first && key.KeyChar < end)
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
