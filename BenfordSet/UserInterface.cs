using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    /// <summary>
    /// Struct <c>Userinterface</c> provides the console output.
    /// The structs like <c>Error</c>, <c>Info</c> and <c>Results</c>
    /// partion the output information.
    /// </summary>

    class Userinterface
    {

    }

    internal class Error //: Userinterface
    {

        public Error() { }
        public static readonly Error error = new Error();
        public void NoFile()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No File available");
            Console.ResetColor();
        }
        public void NoAcess()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No access to file");
            Console.ResetColor();
        }
        public void NoPdf()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The file has the wrong extension");
            Console.ResetColor();
        }
        internal void NotReadable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File is not readable");
            Console.ResetColor();
        }
        public void Terminate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The programm will be terminated due to erros");
            Console.ResetColor();
        }

        public void Exceptions(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();

        }

        public void NoNumbers()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No numbers in the file");
            Console.ResetColor();
        }
    }

    internal class Info : Error
    {
        public void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Start the Benford analysis");
            Console.ResetColor();
        }
        public void CheckFile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File is available");
        }
        public void CheckExtension()
        {
            Console.WriteLine("File is pdf");
        }
        public void CheckFileIsReadable()
        {
            Console.WriteLine("File is readable");
            Console.ResetColor();
        }
        public void Finish()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finish");
            Console.ResetColor();

        }
    }

    internal class Results // : Userinterface
    {
        public void BenfordDistribution()
        {
            throw new NotImplementedException();

        }

        public void BenfordNumbers(double[] digits)
        {
            //double[] benfordNumbers = new double[9] { 30.1, 17.6, 12.5, 9.7, 7.9, 6.7, 5.8, 5.1, 4.6 };
            var benfordNumbers = new[] { 30.1, 17.6, 12.5, 9.7, 7.9, 6.7, 5.8, 5.1, 4.6 };
            Console.WriteLine(benfordNumbers);
            //double[] calcdiff = CalculateDifference(benfordNumbers, digits);
            //PrinResults(benfordNumbers, digits, calcdiff);
        }

        // YourDistribution und Deviation und Benford put together because its just a for loop to print the results
        public void YourDistribution()
        {
            throw new NotImplementedException();
        }

        public void Deviation()
        {
            throw new NotImplementedException();

        }

        //public void ResultMessage();/// (string text)
        //{
        //    Console.WriteLine(new string('#', 59));
        //    Console.WriteLine("hi");
        //    Console.WriteLine(new string('#', 59));
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}

        public void PrinResults()///(double[] benford, double[] digits, double[] difference)
        {
            ///Threshold = 1.5;
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("Filename:\t {0} ", Filename);
            //Console.WriteLine("Page Numbers:\t {0}", GetPageNumber);
            //Console.WriteLine("All Numbers:\t {0}", AllNumbers);
            //Console.WriteLine("Threshold:\t {0} %", Threshold);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nBenford Distribution \t Your Distribution \t Difference ");
            //int counter = 0;
            //for (int i = 0; i <= benford.Length - 1; i++)
            //{
            //    if (Difference[i] < Threshold)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, benford[i], i + 1, digits[i], i + 1, difference[i]);
            //        Console.ForegroundColor = ConsoleColor.Gray;
            //    }
                //    else
                //    {
                //        counter += 1;
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, benford[i], i + 1, digits[i], i + 1, difference[i]);
                //        Console.ForegroundColor = ConsoleColor.Gray;
                //    }
                //}
                //Console.WriteLine("\nThere are differences in {0} cases:\n", counter);

                //if (counter <= 3)
                //{
                //    Console.ForegroundColor = ConsoleColor.Green;
                //    ResultMessage("Status: Might be ok.");
                //}
                //else if (counter == 4 || counter == 5)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkYellow;
                //    ResultMessage("Status: Might be ok.");

                //}
                //else if (counter >= 6)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    ResultMessage("Status: You should take a closer look to the numbers.");
                //}
                //else
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    ResultMessage("Status: Error while computing.");
                //}
            }

        //public void FileInformations(double[] benford, double[] digits, double[] difference)
        //{
        //    // Threshold = 1.5;
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine("Filename:\t {0} ", Filename);
        //    Console.WriteLine("Page Numbers:\t {0}", GetPageNumber);
        //    Console.WriteLine("All Numbers:\t {0}", AllNumbers);
        //    Console.WriteLine("Threshold:\t {0} %", Threshold);
        //}
    }
}
