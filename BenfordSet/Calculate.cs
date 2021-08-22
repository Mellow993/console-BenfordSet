using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    class Calculate : FileAttributes
    {
        //public static readonly Error err = new Error();

        #region "Private Fields"
        private int _countDeviations;
        private double _threshold = 1.5;
        #endregion

        #region "Properties"
        public int CountDeviations { get { return _countDeviations; } private set { _countDeviations = value; } }
        public int[] CountedNumbers { get; private set; }
        public double Threshold { get { return _threshold; } }
        public double[] BenfordNumbers { get;} = { 30.1, 17.6, 12.5, 9.7, 7.9, 6.7, 5.8, 5.1, 4.6 };
        public double[] Digits { get; private set; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] Difference { get; private set; } = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        #endregion

        #region "Public Functions"
        //public Calculate(int allNumbers, int[] countedNumbers)
        //{
        //    this.Allnumbers = allNumbers;
        //    this.CountedNumbers = countedNumbers;
        //}

        public Calculate(Count countObj)
        {
            if(countObj != null)
            {
                NumbersInFile = countObj.NumbersInFile;
                Filename = countObj.Filename;
                FileContent = countObj.FileContent;
                CountedNumbers = countObj.FoundNumbers;
            }
            else
            {
                Error.NoObject();
                throw new ArgumentNullException();
            }
        }

        public void StartCalculation()
        {
            CalculateDistribution();
            Deviation();
            ClassifyResults();
        }

        private void CalculateDistribution()
        {
            if (NumbersInFile != 0)
                for (var k = 0; k <= Digits.Length - 1; k++)
                    Digits[k] = Math.Round(ConvertTypes(CountedNumbers[k]) / NumbersInFile * 100, 1);
            else
                throw new DivideByZeroException(); 
        }

        private double ConvertTypes(int numbers)
        {
            return (double)numbers;
        }
        private void Deviation() 
        {
            for (var k = 0; k < BenfordNumbers.Length; k++)
                Difference[k] = Math.Round(Math.Abs(BenfordNumbers[k] - Digits[k]), 1);
        }
        private void ClassifyResults()
        {
            for (int i = 0; i <= BenfordNumbers.Length - 1; i++)
                if (Difference[i] > Threshold)
                    CountDeviations += 1;
        }
        #endregion
    }
}
