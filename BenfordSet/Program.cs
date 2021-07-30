using System;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics; ///.Process.Start;

namespace BenfordSet
{
    class Programs
    {
        class GetPdf
        {
            public GetPdf(string foldername, string filename)
            {
                this.Foldername = foldername;
                this.Filename = filename;
            }

            public string Filename { get; set; }

            public string Foldername { get; set; }
       
            public string PdfContent { get; set; }
            public string GetFullPath {
                get { return string.Format("{0}{1}", this.Foldername, this.Filename); }
            }
            public string GetFilename()
            {
                return this.Filename;
            }

            public void SetFoldername(string value)
            {
                if (!String.IsNullOrEmpty(value))
                    this.Foldername = value; /// @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik";
                else
                    Console.WriteLine("Enter a foldername");
            }

            public void SetFilename(string value)
            {
                if (!String.IsNullOrEmpty(value))
                    this.Filename = value;
                else
                    Console.WriteLine("Enter a filename");
            }
            public int AllNumbers { get; private set; }

            //public int GetAllNumbers()
            //{
            //    return this.AllNumbers;
            //}

            public void SetAllNumbersToZero()
            {
                this.AllNumbers = 0;
            }

            public int GetPageNumber { get; set; }


            public bool CheckFolder() ///(string foldername)
            {
                //this.Foldername = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";

                if(String.IsNullOrEmpty(Foldername))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No folder path available");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Environment.Exit(1);
                }

                if (System.IO.Directory.Exists(Foldername)) ///(foldername))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The folder exits");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The folder doesn't exits");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Environment.Exit(1);
                    return false;
                }
            }

            public bool CheckFile() ///(string filename)
            {
                //this.Filename = "2012_Book_FEM.pdf";
                if (String.IsNullOrEmpty(Filename))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No filename available");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Environment.Exit(1);
                }

                if (System.IO.File.Exists(Foldername + Filename))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The File exits");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The file doesn't exits");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Environment.Exit(1);
                    return false;
                }     
            }

            public void GetPdfContent()
            {
                using (PdfDocument document = PdfDocument.Open(@GetFullPath)) ///@"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\2012_Book_FEM.pdf"))
                {
                    
                    foreach (Page page in document.GetPages())
                    {
                        IReadOnlyList<Letter> letters = page.Letters;
                        string example = string.Join(string.Empty, letters.Select(x => x.Value));
                        IEnumerable<Word> words = page.GetWords();
                        PdfContent += page.Text;
                        IEnumerable<IPdfImage> images = page.GetImages();
                        GetPageNumber = page.Number;
                    }
                }
            }

            public void CountNumbers(string raw)
            {
                int[] numbers = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                SetAllNumbersToZero();
                Regex regex = new Regex(@"[1-9]*[1-9]");

                foreach (Match match in regex.Matches(raw))
                {
                    AllNumbers += 1;
                    if (match.Value.StartsWith("1"))
                        numbers[0] += 1;

                    else if (match.Value.StartsWith("2"))
                        numbers[1] += 1;

                    else if (match.Value.StartsWith("3"))
                        numbers[2] += 1;

                    else if (match.Value.StartsWith("4"))
                        numbers[3] += 1;

                    else if (match.Value.StartsWith("5"))
                        numbers[4] += 1;

                    else if (match.Value.StartsWith("6"))
                        numbers[5] += 1;

                    else if (match.Value.StartsWith("7"))
                        numbers[6] += 1;

                    else if (match.Value.StartsWith("8"))
                        numbers[7] += 1;

                    else if (match.Value.StartsWith("9"))
                        numbers[8] += 1;
                    else
                        Console.WriteLine("dont knooowww");

                }
                CalculateDistribution(numbers); ///, AllNumbers);
            }

            public void CalculateDistribution(int[] numbers) ///, int AllNumbers)
            {
                
                double[] digits = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                double[] convertNumbers = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                for(int z=0; z <= 8 ; z++)
                {
                    convertNumbers[z] = (double)numbers[z];
                }

                if(AllNumbers != 0)
                {
                    for (int k = 0; k <= 8; k++)
                    {
                        digits[k] = Math.Round(convertNumbers[k] / AllNumbers * 100, 1);
                    }
                }        
                else
                {
                    Console.WriteLine("There are no numbers in the file");
                    Environment.Exit(1);
                }
                BenfordNumbers(digits);
            }


            public void BenfordNumbers(double[] digits)
            {
                double[] benfordNumbers = new double[9] { 30.1, 17.6, 12.5, 9.7, 7.9, 6.7, 5.8, 5.1, 4.6 };
                double[] calcdiff = CalculateDifference(benfordNumbers, digits);

                PrinResults(benfordNumbers, digits, calcdiff);

            }

            public void PrinResults(double[] benford, double[] digits, double[] difference)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Filename:\t {0} ", Filename); 
                Console.WriteLine("Page Numbers:\t {0}", GetPageNumber);
                Console.WriteLine("All Numbers:\t {0}", AllNumbers);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nBenford Distribution \t Your Distribution \t Difference ");
                int counter = 0;
                for (int i = 0; i <= benford.Length - 1; i++)
                {
                    if (difference[i] < 1.5 )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, benford[i], i + 1, digits[i], i + 1, difference[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        counter += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %", i + 1, benford[i], i + 1, digits[i], i + 1, difference[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine("\nThere are differences in {0} cases:\n", counter);

                if (counter <= 3 )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ResultMessage("Status: Might be ok.");
                }
                else if (counter == 4 || counter == 5 )
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    ResultMessage("Status: Might be ok.");

                }
                else if (counter >= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ResultMessage("Status: You should take a closer look to the numbers.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ResultMessage("Status: Error while computing.");
                }
            }

            public void ResultMessage(string text)
            {
                Console.WriteLine("###########################################################");
                Console.WriteLine(text);
                Console.WriteLine("###########################################################");
                Console.ForegroundColor = ConsoleColor.Gray;

            }

            public double[] CalculateDifference(double[] benford, double[] digits)
            {
                double[] difference = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int k = 0; k < benford.Length; k++)
                {
                    difference[k] = Math.Round(Math.Abs(benford[k] - digits[k]), 1);
                }
                return difference;
            }


            public void GetHelpOrQuit()
            {
                while (true)
                {
                    Console.WriteLine("To get more Information about the Benford set enter \"help\" otherwise enter \"exit\" to quit the programm.");
                    string enterOrder = Console.ReadLine().ToLower();
                    if (enterOrder == "help")
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = "https://en.wikipedia.org/wiki/Benford%27s_law",
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                    else if (enterOrder == "exit")
                        Environment.Exit(0);
                    else
                        Console.WriteLine("Dont now what to do");
                }

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Analyse Pdf");
                /// 2013_Book_CFD-Modellierung.pdf
                /// 2014_Book_SystemeVonTurbofan-Triebwerken.pdf
                /// Effective_Python_(2015).pdf
                string fld = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";
                //string file = "2012_Book_FEM.pdf";                        /// positives Beispiel
                //string file = "2015_Book_HandbuchVerbrennungsmotor.pdf";    /// mittel
                string file = "2018_Book_AufgabenUndLösungsmethodikTech.pdf";  /// negatives Bespiel 

                GetPdf pdf = new GetPdf(fld, file);

                pdf.CheckFolder();
                pdf.CheckFile();
                pdf.GetPdfContent();
                pdf.CountNumbers(pdf.PdfContent);
                //pdf.GetHelpOrQuit();
            }
        }
    }
}



//Console.WriteLine("Enter folder path and file name");
//string foldername = Console.ReadLine();
//string filename = Console.ReadLine();
//pdf.SetFoldername(foldername);
//pdf.SetFilename(filename);