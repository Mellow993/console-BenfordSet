//using System;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Collections.Generic;
//using System.Linq;
//using System.Diagnostics; ///.Process.Start;
//using System.Threading;

namespace BenfordSet
{
    class Programs
    {
            static int Main(string[] args)
            {
                ///<summary>This Program analyses text files, like *.pdf, *.txt or web pages
                ///to check if the contained numbers follow the benford set.
                ///This might be helpful to check if the numbers are faked.</summary>
                Check check = new Check(args[0]);
                Error error = new Error();
                Count count = new Count();
                if (check.Requirements()) /// check.CheckSource() && check.FileIsPdf() && check.HasReadAccess()) // one class and this in one method
                {
                    Readpdf read = new Readpdf(args[0]);
                    count.CountNumbers(read.GetContent()); // ???Is it useful to invoke the CountNumber method in that way or is there a better way???
                    
                    Calculate calculate = new Calculate(count.AllNumbers, count.FoundNumbers);
                    calculate.CalculateDistribution();
                    calculate.Deviation();
                    calculate.ClassifyResults();
                    return 0;
                }
                else
                {
                    error.Terminate();
                    return 1;
                }
            }
        }
}


