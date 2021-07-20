using System;
using System.Text;
///using iTextSharp.text.pdf;
using System.Text.RegularExpressions;


namespace BenfordSet
{
    class Programs
    {
        class GetPdf
        {
            public string Filename { get; private set; }
            public string Foldername { get; private set; }

            public string PdfContent { get; private set; }

            public string Numbers { get; set; }


            public void ReadPdf() ///(string Foldername, string Filename)
            {
                string content = System.IO.File.ReadAllText(Foldername + Filename);
                this.PdfContent = content;
            }

            public void SetFoldername()
            {
                this.Foldername = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik";
            }

            public void SetFilename()
            {
                this.Filename = "zahlen"; //"2012_Book_FEM.pdf";
            }

            public bool CheckFolder() ///(string foldername)
            {
                this.Foldername = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";

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
                this.Filename = "zahlen.txt"; ///"2012_Book_FEM.pdf";
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

            public void FindNumbers()
            {


                Regex regex = new Regex(@"[0-9]*[0-9]");

                foreach (Match match in regex.Matches(PdfContent))
                {
                    Console.WriteLine(match.Value.StartsWith("1"));
                    Console.WriteLine(match.Value.StartsWith("4"));

                    Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                }

                //for (int i = 0; i <= PdfContent.Le ngth; i++)
                //{
                //if (regex.IsMatch(PdfContent))
                //{
                //        Console.Write("in if");
                //        if (PdfContent[i].ToString() == "1")
                //        {
                //            Console.WriteLine("1 wurde gefunden zähle 1 hoch");
                //        }
                //        else if (PdfContent[i].ToString() == "4")
                //        {
                //            Console.WriteLine("4 wurde gefunden zähle 1 hoch");
                //        }
                //    }

                //}


                ///Console.WriteLine(Regex.Matches(PdfContent, pattern));
            }

            public void CountNumbers()
            {

            }


            class AnalysePdf : GetPdf
            {
                public int Count { get; set; }

                public int Distribution { get; set; }

                public void CountNumbers(string content)
                {

                }

            }

            static void Main(string[] args)
            {
                Console.WriteLine("Analyse Pdf");
                //string fld = @"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\";
                //string fil = "zahlen.txt";
                GetPdf pdf = new GetPdf();
                pdf.SetFoldername();
                pdf.SetFilename();
                pdf.CheckFolder();
                pdf.CheckFile();
                pdf.ReadPdf();

                pdf.FindNumbers();

            }
        }
    }
}
