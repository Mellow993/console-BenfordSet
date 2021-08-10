using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    internal class Userinterface
    {
        //public string red = "ConsoleColor.Red";
        public string Color { get; set; }
        public string Bar {private get; set; }
        private string test = "hallo test";
        public string Test 
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
            }
        }
    }

    class Error : Userinterface
    {
        internal void NoStringno()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Test); ///("The string is empty");
            //Console.ForegroundColor = ConsoleColor.Gray;
            Console.ResetColor();

        }
        public void NoString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The string is empty");
            Console.ResetColor();

        }
        public void NoFile()
        {
            Console.WriteLine("No File available");
            Console.ResetColor();

        }

        public void NoAcess()
        {
            Console.WriteLine("No access to file");
            Console.ResetColor();

        }

        public void NoPdf()
        {
            Console.WriteLine("The file has the wrong extension");
            Console.ResetColor();


        }
        internal void NotReadable()
        {
            Console.WriteLine("File is not readable");
            Console.ResetColor();

        }
        public void Terminate()
        {
            Console.WriteLine("The programm will be terminated due to erros");
            Console.ResetColor();

        }
    }

    class Info : Error
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
    }

    class Results : Userinterface
    {
        public void Table()
        {
            throw new NotImplementedException();
        }
        public void BenfordDistribution()
        {
            throw new NotImplementedException();

        }
        public void YourDistribution()
        {
            throw new NotImplementedException();
        }

        public void Deviation()
        {
            throw new NotImplementedException();

        }

    }
}
