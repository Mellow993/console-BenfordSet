using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BenfordSet
{
    /// <summary>
    /// The class <c>Count</c> is counting all the numbers which are contained in the analysed file.
    /// </summary>
    internal class Count : FileAttributes
    {
        public int[] FoundNumbers { get; set;} = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 

        public Count(Read redFile)
        {
            if (redFile != null && redFile.FileContent != null)
                FileContent = redFile.FileContent;
            else
            {
                Error.NoObject();
                throw new ArgumentNullException();
            }
        }

        public void CountAllNumbers() 
        {
            Regex regex = new Regex(@"[1-9]*[1-9]"); 
            foreach (Match match in regex.Matches(FileContent))
            {
                NumbersInFile += 1;
                try
                {
                    var number = Int64.Parse(match.Value.ToString());

                    if (number > 10)
                        AssignNumbers(GetFirstDigit(number));
                    else
                        AssignNumbers(number);


                    long GetFirstDigit(long firstDigit)
                    {
                        while (firstDigit >= 10)
                        {
                            firstDigit = (firstDigit - (firstDigit % 10)) / 10;
                        }
                        return firstDigit;
                    }

                    void AssignNumbers(long number)
                    {
                        switch (number)
                        {
                            case 1:
                                FoundNumbers[0] += 1;
                                break;
                            case 2:
                                FoundNumbers[1] += 1;
                                break;
                            case 3:
                                FoundNumbers[2] += 1;
                                break;
                            case 4:
                                FoundNumbers[3] += 1;
                                break;
                            case 5:
                                FoundNumbers[4] += 1;
                                break;
                            case 6:
                                FoundNumbers[5] += 1;
                                break;
                            case 7:
                                FoundNumbers[6] += 1;
                                break;
                            case 8:
                                FoundNumbers[7] += 1;
                                break;
                            case 9:
                                FoundNumbers[8] += 1;
                                break;
                            default:
                                Console.WriteLine("something went wrong");
                                break;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //string test = match.Value.ToString();

                //NumbersInFile += 1;
                //if (match.Value.StartsWith("1"))
                //    FoundNumbers[0] += 1;

                //else if (match.Value.StartsWith("2"))
                //    FoundNumbers[1] += 1;

                //else if (match.Value.StartsWith("3"))
                //    FoundNumbers[2] += 1;

                //else if (match.Value.StartsWith("4"))
                //    FoundNumbers[3] += 1;

                //else if (match.Value.StartsWith("5"))
                //    FoundNumbers[4] += 1;

                //else if (match.Value.StartsWith("6"))
                //    FoundNumbers[5] += 1;

                //else if (match.Value.StartsWith("7"))
                //    FoundNumbers[6] += 1;

                //else if (match.Value.StartsWith("8"))
                //    FoundNumbers[7] += 1;

                //else if (match.Value.StartsWith("9"))
                //    FoundNumbers[8] += 1;
                //else
                //    Console.WriteLine("dont knooowww");
            }


        }
    }
}
