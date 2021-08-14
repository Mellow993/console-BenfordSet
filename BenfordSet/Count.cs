using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BenfordSet
{
    /// <summary>
    /// The class <c>Count</c> is counting all the numbers which are contained in the analysed file.
    /// </summary>
    class Count
    { 
        public int AllNumbers { get; private set; } = 0;
        public int[] FoundNumbers { get; private set; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string Content { get; private set; }
        public void CountNumbers(string Content) 
        {
            Regex regex = new Regex(@"[1-9]*[1-9]");

            if (String.IsNullOrWhiteSpace(Content))
                Environment.Exit(1202);

            foreach (Match match in regex.Matches(Content))
            {
                AllNumbers += 1;

                if (match.Value.StartsWith("1"))
                    FoundNumbers[0] += 1;

                else if (match.Value.StartsWith("2"))
                    FoundNumbers[1] += 1;

                else if (match.Value.StartsWith("3"))
                    FoundNumbers[2] += 1;

                else if (match.Value.StartsWith("4"))
                    FoundNumbers[3] += 1;

                else if (match.Value.StartsWith("5"))
                    FoundNumbers[4] += 1;

                else if (match.Value.StartsWith("6"))
                    FoundNumbers[5] += 1;

                else if (match.Value.StartsWith("7"))
                    FoundNumbers[6] += 1;

                else if (match.Value.StartsWith("8"))
                    FoundNumbers[7] += 1;

                else if (match.Value.StartsWith("9"))
                    FoundNumbers[8] += 1;
                else
                    Console.WriteLine("dont knooowww");
            }
        }
    }
}
