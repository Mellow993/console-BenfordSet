using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    class Userinterface
    {
        public string ConsoleColor { get; set; }
        public string bar { get; set; }

    }

    class Error : Userinterface
    {
        public void NoString()
        {
            Console.WriteLine("The string is empty");
        }
        public void NoFile()
        {
            Console.WriteLine("No File available");
        }

        public void NoAcess()
        {
            Console.WriteLine("No access to file");
        }
        
        public void NoPdf()
        {
            Console.WriteLine("The file has the wrong extension");

        }

        public void NotReadable()
        {
            Console.WriteLine("File is not readable");
        }
    }

    class Info : Userinterface
    {
        public void Welcome()
        {
            Console.WriteLine("Start the Benford analysis");
        }
        public void CheckFile()
        {
            Console.WriteLine("File is available");
        }
        public void CheckExtension()
        {
            Console.WriteLine("File is pdf");
        }
        public void CheckFileIsReadable()
        {
            Console.WriteLine("File is readable");
        }
    }

    class Results : Userinterface
    {

    }
}
