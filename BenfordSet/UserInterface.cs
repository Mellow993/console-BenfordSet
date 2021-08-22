using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    /// <summary>
    /// The structs like <c>Error</c>, <c>Info</c> and <c>Results</c>
    /// partion the output information.
    /// </summary>


    class Userinterface
    {
        public ConsoleColor Color { get; set; }
        public void Hallo()
        {
            Console.WriteLine("Hallo how can I call that?");
        }
    }


    #region "Error Outputs"
    static internal class Error 
    {
        static public string OutputError()
        {
            return "Error: ";
        }

        static public void NoObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "NO OBJECT AVAILABLE");
            Console.ResetColor();
        }
        static public void NoFile()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "NO FILE AVAILABLE");
        }
        static public void NoAcess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "NO ACCESS TO THE FILE");
            Console.ResetColor();
        }
        static public void NoPdf()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "THE FILE IS NOT A PDF");
            Console.ResetColor();
        }
        static internal void NotReadable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "THE FILE IS NOT READLABLE");
            Console.ResetColor();
        }
        static public void Terminate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "THE PROGRAMM WILL BE TERMINATED DUE TO ERROS");
            Console.ResetColor();
        }

        static public void Exceptions(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + message);
            Console.ResetColor();

        }

        static public void NoNumbers()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OutputError() + "NO NUMBERS IN THE FILE.");
            Console.ResetColor();
        }
    }
    #endregion

    #region "Info Outputs"
    static public class Info 
    {
        static public void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Start the Benford analysis.");
            Console.ResetColor();
        }

        static public string OutputInfo()
        {
            return "Info: ";
        }
        static public void CheckFile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(OutputInfo() + "File is available");
            Console.ResetColor();
        }
        static public void CheckExtension()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(OutputInfo() + "File is pdf");
            Console.ResetColor();
        }
        static public void CheckFileIsReadable()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(OutputInfo() + "File is readable");
            Console.ResetColor();
        }
        static public void Finish()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(OutputInfo() + "Analysis completed.");
            Console.ResetColor();
        }
    }
    #endregion

    #region "Result Outputs"
    class Results
    {
        public void StartOutput(Calculate calcObj)
        {
            if (calcObj != null)
            {
                ResultHeader();
                ShowResults(calcObj);
            }
            else
            {
                Error.NoObject();
                throw new ArgumentNullException();
            }
        }

        private void ResultHeader() /// (string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            Console.WriteLine(new string('#', 59));
            Console.WriteLine("Results of the benford analysis.");
            Console.WriteLine(new string('#', 59));
            Console.ResetColor();
        }
        private void PrintDeviation(int countDeviations)
        {
            Console.WriteLine("\nThere are differences in {0} cases.", countDeviations);

            EvaluateDeviation(countDeviations);
        }
        private void ShowResults(Calculate calcObj)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Threshold:\t {0} %", calcObj.Threshold);
            Console.WriteLine("Filename:\t {0}", calcObj.Filename);
            Console.WriteLine("Counted Numbers: {0}", calcObj.NumbersInFile);
            Console.WriteLine("\nBenford Distribution \t Your Distribution \t Difference ");

            for (var i = 0; i < calcObj.CountedNumbers.Length; i++)
            {
                if (calcObj.Difference[i] < calcObj.Threshold)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, calcObj.BenfordNumbers[i], i + 1, calcObj.Digits[i], i + 1, calcObj.Difference[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, calcObj.BenfordNumbers[i], i + 1, calcObj.Digits[i], i + 1, calcObj.Difference[i]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            PrintDeviation(calcObj.CountDeviations);
        }

        private void EvaluateDeviation(int counter)
        {
            switch (counter)
            {
                case var n when (n <= 3):
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Status: Might be ok.");
                    break;
                case var n when (n == 4 || n == 5):
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Status: Might be ok.");
                    break;
                case var n when (n >= 6):
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Status: You should take a closer look to the numbers.");
                    break;
            }
            Console.ResetColor();
        }
    }
    #endregion
}

