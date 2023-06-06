using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserTest
{
    class Program
    {
        private static readonly string[][] TEST_DATA = new string[][]
        {
            new []{ "" },
            new []{ (string)null },
            new []{ "test Test", "teSt", "test"},
            new []{ "\t\r\ntest\t TeSt", "test", "test"},
            new []{ "!@#$test1__TeSt2%^&*", "test1", "test2"},
            new []{ "()^%$test1__TeSt2--&*tes3t", "test1", "test2", "tes3t"},
            new []{ "!@#$1234test__TeSt++^-*tes3t==", "1234test", "test", "tes3t"},
        };

        static void Main(string[] args)
        {
            // Problem:
            // Update StringParser Parse() method so it would return list of substrings from the supplied input string.
            // Each substring should be continuous sequence of alphanumeric characters.
            // The sample TEST_DATA are given above, please feel free to extend it if neccessary.
            // The current implementation passes 4 first cases but fails the rest.
            // Please ensure the implementation is production quality- simple, easy to maintain, doesn't allocate unnecessary memory and has performance O(n) where n- length of the input string. The current implementation does not meet these requirements.

            StringParser parser = new StringParser();

            for (int i = 0; i < TEST_DATA.Length; i++)
            {
                string[] data = TEST_DATA[i];

                string s = data[0];

                try
                {
                    List<string> lst = parser.Parse(s);

                    if (data.Skip(1).SequenceEqual(lst, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{i}: passed ...");
                    }
                    else
                    {
                        Console.WriteLine($"{i}: not passed ...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{i}: error: '{ex.Message}'");
                }
            }


            // Solution by Leonardo Santos-Macias, using Parse2() method
            Console.WriteLine("\nForst solution by Leonardo Santos-Macias. Using a regex. Did not pass all tests");
            for (int i = 0; i < TEST_DATA.Length; i++)
            {
                string[] data = TEST_DATA[i];

                string s = data[0];

                try
                {
                    List<string> lst = parser.Parse2(s);

                    if (data.Skip(1).SequenceEqual(lst, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{i}: passed ...");
                    }
                    else
                    {
                        Console.WriteLine($"{i}: not passed ...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{i}: error: '{ex.Message}'");
                }
            }

            // Solution by Leonardo Santos-Macias, using Parse3() method
            Console.WriteLine("\nSecond solution by Leonardo Santos-Macias. Using a regex. It passes all tests");
            for (int i = 0; i < TEST_DATA.Length; i++)
            {
                string[] data = TEST_DATA[i];

                string s = data[0];

                try
                {
                    List<string> lst = parser.Parse3(s);

                    if (data.Skip(1).SequenceEqual(lst, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{i}: passed ...");
                    }
                    else
                    {
                        Console.WriteLine($"{i}: not passed ...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{i}: error: '{ex.Message}'");
                }
            }

            Console.ReadLine();

        }
    }
}
