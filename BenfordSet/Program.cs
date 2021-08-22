using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//using System.Text;
//using System.Text.RegularExpressions;
//using System.Collections.Generic;
//using System.Linq;
//using System.Diagnostics; ///.Process.Start;
//using System.Threading;

namespace BenfordSet
{
    class Programs
    {

        ///<summary>This Program analyses text files, like *.pdf, *.txt or web pages
        ///to check if the contained numbers follow the benford set.
        ///This might be helpful to check if the numbers are faked.</summary>
        ///
        private static readonly Userinterface test = new Userinterface();

        static async Task<int> Main(string[] args)
        {
            if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0])) // is that the same?
                return 1;

            var pathToFile = args;
            //FileAttributes myFile;
            //myFile = new FileAttributes()
            var fileAttributes = new FileAttributes() { SourceFile = pathToFile[0] };
            fileAttributes.SetFilename();

           

            var fileInput = new FileInput(fileAttributes); // Zweite Klasse

            if (fileInput.Requirements())
            {
                var readFile = new Read(ref fileAttributes);
                await readFile.GetFileContent();

                var count = new Count(readFile);
                count.CountAllNumbers();

                var calculate = new Calculate(count);
                calculate.StartCalculation();

                var output = new Results();
                output.StartOutput(calculate);
            }
            else
            {
                Error.Terminate();
                return 1;
            }
            return 0;
        }
    }
}





//public static readonly Info info = new Info(); 
//public static readonly Results results = new Results();

//Notizen
//    Wenn Konstruktor in der obersten klasse benötigt wird //var fileAttributes = new FileAttributes(pathToFile[0]);
