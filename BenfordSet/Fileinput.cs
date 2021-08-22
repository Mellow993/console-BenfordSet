using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BenfordSet
{
    class FileInput : FileAttributes
    {
        /// <summary>
        /// The abstract Class <c>Datainput</c> provides some the methods to check if the file is
        /// available, readable and a pdf.
        /// </summary>
        public FileInput(FileAttributes fa)  //: base(pathToFile) { }
        {
            if (fa != null && fa.SourceFile != null)
                SourceFile = fa.SourceFile;
            else
            {
                Error.NoObject();
                throw new ArgumentNullException();
            }
        }
        public bool Requirements()
        {
            if (CheckSource() && HasReadAccess() && FileIsPdf())
                return true;
            else
                return false;
        }
        private bool CheckSource() ///(string file)
        {
            if (File.Exists(SourceFile)) 
            {
                Info.CheckFile();
                return true;
            }

            else 
            {
                Error.NoFile();
                return false;
            }
        }
        private bool HasReadAccess() 
        {
            FileInfo fi = new FileInfo(SourceFile);
            if (!fi.IsReadOnly)
            {
                Info.CheckFileIsReadable();
                return true;
            }
            else
            {
                Error.NotReadable();
                return false;
            }
        }

        private bool FileIsPdf()
        {
            FileInfo fi = new FileInfo(SourceFile);

            if (fi.Extension.Contains("pdf"))
            {
                Info.CheckExtension();
                return true;
            }
            else
            {
                Error.NoPdf();
                return false;
            }
        }
    }
}
