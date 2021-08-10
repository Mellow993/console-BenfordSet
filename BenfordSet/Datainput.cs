using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BenfordSet
{
    abstract class Datainput
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

        abstract public bool CheckSource(); ///string file);
        abstract public bool HasReadAccess(); /// (string file);
        abstract public bool FileIsPdf();//// (string file);
    }

    class Check : Datainput
    {
        public Check(string source) : base(source) { }
        Info info = new Info();
        Error error = new Error();

        Userinterface ui = new Userinterface();
        //FileInfo test = new FileInfo();

        public override bool CheckSource() ///(string file)
        {
            if (File.Exists(Source))
            {
                info.CheckFile();
                return true;
            }

            else
            {
                error.NoFile();
                return false;
            }

        }

        public override bool HasReadAccess() /// (string file)
        {
            FileInfo fi = new FileInfo(Source);
            if (!fi.IsReadOnly)
            {
                info.CheckFileIsReadable();
                return true;
            }
            else
            {
                error.NotReadable();
                return false;
            }

        }
        public override bool FileIsPdf()
        {
            FileInfo fi = new FileInfo(Source);

            if (fi.Extension.Contains("pdf"))
            {
                info.CheckExtension();
                return true;
            }
            else
            {
                error.NoPdf();
                return false;
            }

        }
    }

}
