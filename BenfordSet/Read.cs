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
        public int GetPageNumber { get; set; }
        public string Content { get; set; }

        abstract public void GetContent();

    }
    class Readpdf : Read
    {
        public Readpdf(string content)
        {
            this.Content = content;
        }
        override public void GetContent()
        {
            using (PdfDocument document = PdfDocument.Open(Content)) ///@"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\2012_Book_FEM.pdf"))
            {

                foreach (Page page in document.GetPages())
                {
                    //IReadOnlyList<Letter> letters = page.Letters;
                    //string example = string.Join(string.Empty, letters.Select(x => x.Value));
                    //IEnumerable<Word> words = page.GetWords();
                    Content += page.Text;
                    //IEnumerable<IPdfImage> images = page.GetImages();
                    GetPageNumber = page.Number;
                }
                Console.WriteLine(Content);
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
}
