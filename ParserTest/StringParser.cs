using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParserTest
{
    class StringParser
    {
        /*
         * The Parse(...) method takes an inputText parameter and returns a List<string> containing the parsed substrings.
         * 
         * Each substring "should be" a continuous sequence of alphanumeric characters.
         */

        public List<string> Parse(string inputText)
        {
            List<string> lst = new List<string>();

            if (!string.IsNullOrEmpty(inputText))
            {
                lst.AddRange(inputText.Split().Where(s => !string.IsNullOrEmpty(s)));
            }

            return lst;
        }


        /*
         * The Parse2(...) method is a modification of the above Parse(...) method that takes an inputText parameter and returns a List<string> containing 
         * the parsed substrings, hoping each substring is  be continuous sequence of alphanumeric characters.
         * 
         * The implementation of the Parse() method splits the inputText string based on whitespace using inputText.Split(). It then filters out any empty 
         * or null substrings using Where(s => !string.IsNullOrEmpty(s)). The filtered substrings are added to the lst list using lst.AddRange().
         * However, this implementation splits the inputText string based on whitespace, but it doesn't consider the requirement to extract continuous 
         * sequences of alphanumeric characters. A better implementation would be to use regular expressions.
         * 
         * In this updated implementation, the Parse2(...) method uses a regular expression pattern (@"\w+") to match continuous sequences of alphanumeric 
         * characters. It finds all matches of the pattern in the inputText string using Regex.Matches. The matches are then added to the substrings list, 
         * which is returned as the result.
         * 
         * This implementation IS production quality- simple, easy to maintain, doesn't allocate unnecessary memory and has performance O(n) where
         * n- length of the inputText string, as it takes ony ONE inputText).
         * 
         * Update: turns out some tests are still negative, I tried other similar "alphanum, no spaces" regex expressions. Need further tests and refining!
         */

        public List<string> Parse2(string inputText)
        {
            List<string> substrings = new List<string>();

            if (!string.IsNullOrEmpty(inputText))
            {

                // Use regular expression to match continuous sequences of alphanumeric characters
                //string pattern = @"\w+";
                //string pattern = @"\b\w+\b";
                //string pattern = @"[^\W_]+";
                //string pattern = @"\b[^\W_]+\b";
                string pattern = @"\b[a-zA-Z0-9]+\b";


                // Find all matches of the pattern in the inputText string
                MatchCollection matches = Regex.Matches(inputText, pattern);

                // Iterate over each match and add it to the list of substrings
                foreach (Match match in matches)
                {
                    substrings.Add(match.Value.ToLower());
                }

            }

            return substrings;
        }

        /*
         * The Parse3(...) method is a modification of the above Parse(...) method that takes an inputText parameter and returns a List<string> containing 
         * the parsed substrings.
         * 
         * The implementation of the Parse() method splits the inputText string based on whitespace using inputText.Split(). It then filters out any empty 
         * or null substrings using Where(s => !string.IsNullOrEmpty(s)). The filtered substrings are added to the lst list using lst.AddRange().
         * However, this implementation splits the inputText string based on whitespace, but it doesn't consider the requirement to extract continuous 
         * sequences of alphanumeric characters. A better implementation would be to use regular expressions, but in Parse2(...), I could not get the appropiate expression.
         * 
         * In this updated implementation, I will just follow some logic of Parse(...) and skip regular expressions.
         * Inside the Parse() method, you can use a loop to iterate through the characters of the input string and identify continuous sequences of alphanumeric characters.

         * I do initialize a List<string> to store the substrings found. Then I did the follwoing steps:
         * Define variables to keep track of the start index (startIndex) and end index (endIndex) of the current alphanumeric sequence. 
         * Initially, set startIndex to -1 to indicate that no sequence has been started.
         * Iterate through each character of the input string using a for loop. Check if the character is alphanumeric using the char.IsLetterOrDigit() method.
         * If startIndex is -1 and the current character is alphanumeric, set startIndex to the current index.
         * If startIndex is not -1 and the current character is not alphanumeric, it means the alphanumeric sequence has ended. 
         * Set endIndex to the previous index, and extract the substring from startIndex to endIndex.
         * Add the extracted substring to the List<string> and set startIndex back to -1 to indicate the start of a new sequence.
         * After the loop ends, check if startIndex is not -1. This handles the case where the last sequence in the input string extends until the end. 
         * If so, extract the substring from startIndex to the end of the string and add it to the List<string>.
         * Finally, return the List<string> containing all the extracted substrings.
         * 
         * Performance: This implementation IS production quality- simple, easy to maintain, doesn't allocate unnecessary memory and has performance O(n) where
         * n- length of the inputText string, as it takes ony ONE inputText and requires a single pass through the input string to extract the substrings. 
         * This means that the execution time of the method grows linearly with the size of the input. Since the method processes each character exactly 
         * once and performs simple operations without any nested loops or recursion, it is considered an efficient time complexity for string parsing operations.
         * 
         * Memory  allocation: the method uses a List<string> to store the extracted substrings. The memory required for the list is proportional 
         * to the number of substrings found, rather than the size of the input string. Therefore, the memory usage depends on the structure and content 
         * of the input string and the number of alphanumeric sequences present within it. The method avoids unnecessary memory allocations and provides 
         * a simple and easy-to-maintain solution. We tested with a small data set so memory usage is low as well.

         */
        public List<string> Parse3(string inputText)
        {
            List<string> substrings = new List<string>();

            if (!string.IsNullOrEmpty(inputText))
            {


                int startIndex = -1;
                int endIndex = -1;

                for (int i = 0; i < inputText.Length; i++)
                {
                    char currentChar = inputText[i];

                    if (char.IsLetterOrDigit(currentChar))
                    {
                        if (startIndex == -1)
                        {
                            startIndex = i;
                        }
                    }
                    else if (startIndex != -1)
                    {
                        endIndex = i - 1;
                        string substring = inputText.Substring(startIndex, endIndex - startIndex + 1);
                        substrings.Add(substring);
                        startIndex = -1;
                    }
                }

                if (startIndex != -1)
                {
                    string substring = inputText.Substring(startIndex);
                    substrings.Add(substring);
                }
            }

            return substrings;
        }
    }
}
