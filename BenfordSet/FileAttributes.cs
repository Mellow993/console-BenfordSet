using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    class FileAttributes
    {
        #region "Private fields"
        private string _sourceFile = string.Empty;
        private string _filename = string.Empty;
        private string _fileContent = string.Empty;
        private int _numbersInFile = 0;
        private int _pageNumbers = 0; //not implemented yet
        #endregion

        #region "Properties"
        public string SourceFile { get { return _sourceFile; }  
            internal set 
            {
                if (!string.IsNullOrEmpty(value))
                    _sourceFile = value;
                else
                    throw new ArgumentException();
            } 
        }
        public string Filename { get { return _filename; } protected set { _filename = value; } }
        public string FileContent { get { return _fileContent; } protected set { _fileContent = value; } }
        public int NumbersInFile { get { return _numbersInFile; } protected set { _numbersInFile = value; } }
        public int PageNumbers { get { return _pageNumbers; } protected set { _pageNumbers = value; } } //not implemented yet
        #endregion

        public override string ToString()
        {
            return Path.GetFileName(SourceFile); //base.ToString();
        }

        public void SetFilename()
        {
            Filename = Path.GetFileName(SourceFile);
            Console.WriteLine(Filename);
        }

        public FileAttributes() 
        {
        }
    }
}
