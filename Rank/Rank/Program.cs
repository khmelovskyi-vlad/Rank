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
            Console.WriteLine($"Your simbol rank is {test}");
            Console.ReadKey();
        }
        static int Rank ()
        {
            string numAndBracket = ReadString("string with numbers, '(' and ')' ");
            int rank = 0;
            while (true)
            {
                char num = CharRead("your simbol or click escape");
                Console.WriteLine();
                int numInString = IntRead("number your simbol in string or click escape");
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
                    else if (numAndBracket[i] == num && numInString != 1)
                    {
                        numInString--;
                    }
                    else if (numAndBracket[i] == num && numInString == 1)
                    {
                        return rank;
                    }
                }
                    Console.WriteLine("Don`t have your simbol in string");
                    continue;
            }
        }
        static string ReadString(string readString)
        {
            Console.WriteLine($"Enter {readString}");
            (string line, int leftBracket, int rightBracket) = NullArguments();
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
                else
                {
                    var flag = ElseLine(leftBracket, rightBracket, key);
                    if (flag)
                    {
                        return line;
                    }
                    (line, leftBracket, rightBracket) = NullArguments();
                }
            }
        }
        static bool ElseLine(int leftBracket, int rightBracket, ConsoleKeyInfo key)
        {
            var flag = false;
            Console.WriteLine();
            if (key.Key == ConsoleKey.Enter)
            {
                if (leftBracket == rightBracket)
                {
                    flag = true;
                    return flag;
                }
                Console.WriteLine($"Bet input '(' != ')', try again or click escape");
                return flag;
            }
            Console.WriteLine($"Bet input {key.KeyChar}, try again or click escape");
            return flag;
        }
        static (string line, int leftBracket, int rightBracket) NullArguments()
        {
            string line = "";
            int leftBracket = 0;
            int rightBracket = 0;
            return (line, leftBracket, rightBracket);
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
                    Console.WriteLine($"Bet input, try again or click escape");
                    Console.WriteLine($"Enter {readChar}");
                    continue;
                }
            }
        }
        static int IntRead(string readChar)
        {
            Console.WriteLine($"Enter {readChar}");
            do
            {
                try
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        throw new OperationCanceledException();
                    }
                    var line = Console.ReadLine();
                    var keyLine = $"{key.KeyChar}{line}";
                    return Convert.ToInt32(keyLine);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"Ber input {ex.Message}, try again or click Escape");
                }
            } while (true);
        }
    }
}
