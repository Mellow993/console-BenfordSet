using System;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Collections.Generic;
using System.Linq;


namespace BenfordSet
{
    class Programs
    {
        class GetPdf
        {
            public string Filename { get; private set; }
            public string Foldername { get; private set; }
            public string PdfContent { get; set; }

            public void ReadPdf() 
            {
                string content = System.IO.File.ReadAllText(Foldername + Filename);
                this.PdfContent = content;
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
                if(!String.IsNullOrEmpty(value))
                    this.Filename = value; ///"2012_Book_FEM.pdf";
                else
                    Console.WriteLine("Enter a filename");
            }
            public int AllNumbers { get; private set; }


            public bool CheckFolder() ///(string foldername)
            {
                this.Foldername = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";

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
                this.Filename = "2012_Book_FEM.pdf";
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

            //public void GetPdfContent()
            //{
            //    using (PdfDocument document = PdfDocument.Open(@"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\2012_Book_FEM.pdf"))
            //    {
            //        foreach (Page page in document.GetPages())
            //        {
            //            IReadOnlyList<Letter> letters = page.Letters;
            //            string example = string.Join(string.Empty, letters.Select(x => x.Value));
            //            //Console.WriteLine(example);
            //            IEnumerable<Word> words = page.GetWords();

            //            IEnumerable<IPdfImage> images = page.GetImages();
            //            //Console.WriteLine(images);
            //            //PdfContent = example;
            //        }
            //    }
            //}

            public void CountNumbers(string raw)
            {
                int[] numbers = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int AllNumbers = 0;

                Regex regex = new Regex(@"[0-9]*[0-9]");

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
                        Console.WriteLine("I dont know what to do....");
                }

                for (int i = 1; i <= 9; i++)
                {
                    Console.WriteLine("Anzahl der Zahl {0}: {1}", i, numbers[i - 1]);
                }
                Console.WriteLine("All numbers in the file: {0}", AllNumbers);
                CalculateDistribution(numbers, AllNumbers);
            }

            public void CalculateDistribution(int[] numbers, int AllNumbers)
            {
                double[] digits = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                double[] convertNumbers = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                Console.WriteLine(AllNumbers);

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

                foreach (int digit in digits)
                {
                    Console.WriteLine(digit + " %");
                }
                BenfordNumbers(digits);
            }


            public void BenfordNumbers(double[] digits)
            {
                double[] benfordNumbers = new double[9] { 30.1, 17.6, 12.5, 9.7, 7.9, 6.7, 5.8, 5.1, 4.6 };

                //foreach (double num in benfordNumbers)
                //    Console.WriteLine(num + "\t%");
                PrinResults(benfordNumbers, digits);
            }

           

            public void PrinResults(double[] benford, double[] digits)
            {
                Console.WriteLine("Benford Distribution \t Your Distribution \t Difference ");
                for (int i = 0; i <= benford.Length - 1; i++)
                {
                    Console.WriteLine("{0}: {1} % \t\t {2}: {3} %  \t\t {4}: {5} %",i+1, benford[i], i+1, digits[i], i+1,i);
                }
            }


            static void Main(string[] args)
            {
                Console.WriteLine("Analyse Pdf");
                //string fld = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";
                //string fil = "zahlen.txt";
                GetPdf pdf = new GetPdf();
                //Console.WriteLine("Enter folder path and file name");
                //string foldername = Console.ReadLine();
                //string filename = Console.ReadLine();
                //pdf.SetFoldername(foldername);
                //pdf.SetFilename(filename);
                pdf.CheckFolder();
                pdf.CheckFile();
                ///pdf.ReadPdf();
                ///                
                using (PdfDocument document = PdfDocument.Open(@"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\2012_Book_FEM.pdf"))
                {
                    //string rawText = "";
                    foreach (Page page in document.GetPages())
                    {
                        IReadOnlyList<Letter> letters = page.Letters;
                        string example = string.Join(string.Empty, letters.Select(x => x.Value));
                        IEnumerable<Word> words = page.GetWords();
                        string rawText = "";
                        rawText += page.Text;
                        pdf.PdfContent += rawText;
                        IEnumerable<IPdfImage> images = page.GetImages();
                        pdf.PdfContent += rawText;
                    }
                   
                    
                    pdf.CountNumbers(pdf.PdfContent);
                    ///pdf.BenfordNumbers();
                }

            }
        }
    }
}
