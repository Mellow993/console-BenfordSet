using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BenfordSet
{
    abstract internal  class Datainput
    {
        // Konstruktor

        public Datainput(string source)
        {
            this.Source = source;
        }
        string source;
        public string Source 
        { 
            get
            {
                return this.source;
            }
            
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    this.source = value;
                //else
                    //error.NoString();
            }
        }

        abstract public void CheckSource(string file);
        abstract public void HasReadAccess(string file);

        abstract public void FileIsPdf(string file);
    }

    class Check : Datainput
    {
        public Check(string source) : base(source) { }
        Info info = new Info();
        Error error = new Error();

        Userinterface ui = new Userinterface();
        //FileInfo test = new FileInfo();

        public override void CheckSource(string file)///(string file)
        {
            if (File.Exists(file))
                info.CheckFile();
            else
                error.NoFile();
        }

        public override void HasReadAccess(string file)
        {
            FileInfo fi = new FileInfo(file);
            if (!fi.IsReadOnly)
                info.CheckFileIsReadable();
            else
                error.NotReadable();
        }
        public override void FileIsPdf(string file)
        {
            FileInfo fi = new FileInfo(file);

            //File
            if (fi.Extension.Contains("pdf"))
                info.CheckExtension();
            else
                error.NoPdf();
        }
    }

}
