using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Threading;
using System.Threading.Tasks;

namespace BenfordSet
{
    /// <summary>
    /// The abstract Class <c>Read</c> provides some properties and the method Getcontent.
    /// The subclasses like <c>Readpdf</c>, <c>Readtextfile</c>, <c>Readwordfile</c> and <c>Readwebpage</c>
    /// provides the functionality to read diffrent types of files.
    /// </summary>

    abstract class Read
    {
        public string Source { get; protected set; }
        public int PageNumber { get; protected set; } = 0;
        public string Information { get; protected set; }
        public string Content { get; protected set; } = "";
        abstract public string GetContent();
    }

     class Readpdf : Read
    {
        //static AutoResetEvent waiter = new AutoResetEvent(true);
        public Readpdf(string source)
        {
            this.Source = source;
        }
        override public string GetContent()
        {
            Error err = new Error();
            /// <summary>
            /// The inherited method GetContent is reading the pdf content and invokes 
            /// the CountNumber method for analysing issues.
            /// </summary>+
            try
            {
                //waiter.Set();
                using PdfDocument document = PdfDocument.Open(Source);
                foreach (Page page in document.GetPages())
                {
                    ReadingCompleted(page); // += readFilesCompleted;
                    //await ReadingCompleted(page);
                }

                //Task.WaitAll(Test());
                //Console.WriteLine("junger thread?");

                //waiter.WaitOne();
                if (String.IsNullOrWhiteSpace(Content))
                    return string.Empty;
                else
                    return Content;
            }
            catch(ArgumentException e)
            {
                err.Exceptions(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                err.Exceptions(e.Message);

            }
            catch(OutOfMemoryException e )
            {
                err.Exceptions(e.Message);
            }
            catch (Exception e)
            {
                err.Exceptions(e.Message);
            }
            return string.Empty;
        }

        async Task<bool> Test()
        {
            Console.WriteLine("neuer thread?");
            await Task.Run(() =>
            {
                Console.WriteLine("warte");
                //System.Threading.Thread.Sleep(10000);
                Console.ReadLine();
                Console.WriteLine("wieder da");

            });
            return true;
        }

        public void ReadingCompleted(Page p)
        {
            Content += p.Text;
            PageNumber = p.Number;
        }

        static void readFilesCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("reading completed");
        }
    }

    //class Readtextfile : Read
    //{
    //    public override string GetContent()
    //    {
    //        try
    //        {
    //        }
    //        catch
    //        {
    //            return 1;
    //        }
    //        return 0;

    //    }
    //}

    //class Readwordfile : Read
    //{
    //    public override string GetContent()
    //    {
    //        return 0;
    //    }
    //}

    //class Readwebpage : Read
    //{
    //    public override string GetContent()
    //    {
    //        return 0;
    //    }
    //}
}


// Not used properties
//public int ImageNumber { get; protected set; }
//public string Filename { get; set; }


//ImageNumber = page.NumberOfImages;
//IReadOnlyList<Letter> letters = page.Letters;
//string example = string.Join(string.Empty, letters.Select(x => x.Value));
//IEnumerable<Word> words = page.GetWords();
//IEnumerable<IPdfImage> images = page.GetImages();