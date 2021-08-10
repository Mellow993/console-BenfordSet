using System;
using System.Collections.Generic;
using System.Text;

namespace BenfordSet
{
    class Analyse
    {
        public int AllNumbers { get; set; }
        public void  CalculateDistribution()
        {}
        public double[] CalculateDifference(double[] benford, double[] digits)
        {
            double[] difference = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int k = 0; k < benford.Length; k++)
            {
                difference[k] = Math.Round(Math.Abs(benford[k] - digits[k]), 1);
            }
            return difference;
        }
    }
}
