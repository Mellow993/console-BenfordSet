using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BenfordSet
{
    /// <summary>
    /// The abstract Class <c>Read</c> provides some properties and the method Getcontent.
    /// The subclasses like <c>Readpdf</c>, <c>Readtextfile</c>, <c>Readwordfile</c> and <c>Readwebpage</c>
    /// provides the functionality to read diffrent types of files.
    /// </summary>

    class Read : FileAttributes
    {
        public Read(ref FileAttributes fileattributes)  //: base(pathToFile) { }
        {
            if (fileattributes != null)
            {
                SourceFile = fileattributes.SourceFile;
                Filename = Path.GetFileName(SourceFile);
            }
            else
            {
                Error.NoObject();
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> GetFileContent()
        {
            try
            {
                using PdfDocument document = PdfDocument.Open(SourceFile);
                foreach (var page in document.GetPages())
                {
                    FetchContent(page); // += readFilesCompleted;
                }
                if (String.IsNullOrEmpty(FileContent))
                    Error.NotReadable();

            }

            #region "Exception handling"
            catch (ArgumentNullException e)
            {
                Error.Exceptions(e.Message);
            }
            catch (ArgumentException e)
            {
                Error.Exceptions(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Error.Exceptions(e.Message);
            }
            catch (Exception e)
            {
                Error.Exceptions(e.Message);
            }
            return true;
        }
        #endregion
        private void FetchContent(Page p)
        {
            if (p != null)
            {
                FileContent += p.Text;
                PageNumbers = p.Number;
            }
            else
                throw new ArgumentException();
        }
    }
}
