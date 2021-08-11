using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace BenfordSet
{
    abstract class Read
    {
        public string Source { get; set; }
        public int PageNumber { get; protected set; }
        public int ImageNumber { get; protected set; }
        public string Information { get; protected set; }
        public string Content { get; protected set; }

        abstract public void GetContent();

    }
    class Readpdf : Read
    {
        public Readpdf(string source)
        {
            this.Source = source;
        }
        override public void GetContent()
        {
            try
            {
                using (PdfDocument document = PdfDocument.Open(Source))
                {
                    foreach (Page page in document.GetPages())
                    {
                        Content += page.Text;
                        PageNumber = page.Number;
                        ImageNumber = page.NumberOfImages;
                        //IReadOnlyList<Letter> letters = page.Letters;
                        //string example = string.Join(string.Empty, letters.Select(x => x.Value));
                        //IEnumerable<Word> words = page.GetWords();
                        //IEnumerable<IPdfImage> images = page.GetImages();
                    }
                    Console.WriteLine(Content);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    class Readtextfile : Read
    {
        public override void GetContent()
        {
            throw new NotImplementedException();
        }
    }

    class Readwordfile : Read
    {
        public override void GetContent()
        {
            throw new NotImplementedException();
        }
    }

    class Readwebpage : Read
    {
        public override void GetContent()
        {
            throw new NotImplementedException();
        }
    }
}
