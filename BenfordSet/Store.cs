using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    abstract class Export
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        abstract public void Save(string destination); 
    }

    class WriteToHardDrive : Export
    {
        public override void Save(string destination)
        {
            throw new NotImplementedException();
        }
    }
    class WriteToTextFile : WriteToHardDrive
    {
        public override void Save(string destination)
        {
            throw new NotImplementedException();
        }
    }
    class CreatePdfFile : WriteToHardDrive
    {
        public override void Save(string destination)
        {
            throw new NotImplementedException();
        }
    }
    class WriteToCloud : Export
    {
        public override void Save(string destination)
        {
            throw new NotImplementedException();
        }
    }
    class WriteToFTP : Export
    {
        public override void Save(string destination)
        {
            throw new NotImplementedException();
        }
    }
}
