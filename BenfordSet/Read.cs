using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    class Read
    {
        public int GetPageNumber { get; set; }
        // use events or threads to make the programm fast

        //public void GetPdfContent()
        //{
        //    using (PdfDocument document = PdfDocument.Open(@GetFullPath)) ///@"C:\Users\rennd\OneDrive\Dokumente\Bücher\StrukturDynamik\2012_Book_FEM.pdf"))
        //    {

        //        foreach (Page page in document.GetPages())
        //        {
        //            //IReadOnlyList<Letter> letters = page.Letters;
        //            //string example = string.Join(string.Empty, letters.Select(x => x.Value));
        //            //IEnumerable<Word> words = page.GetWords();
        //            PdfContent += page.Text;
        //            //IEnumerable<IPdfImage> images = page.GetImages();
        //            GetPageNumber = page.Number;
        //        }
        //    }
        //}
    }
}
