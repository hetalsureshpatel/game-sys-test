using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesSys.Logic
{
    public class Generator
    {
        public List<double> Generate(double x, double y, int size)
        {
            var firstNumber = FirstNumber(x);
            var growthRate = GrowthRate(firstNumber, y);
            var list = GenerateSeries(firstNumber, growthRate, size);

            var query = from i in list
                        orderby i ascending
                        select i;

            return query.ToList();
        }

        public double GetNumberOne(double x, double y, int size)
        {
            var list = Generate(x, y, size);

            return list.Count >= 3 ? list[2] : 0.0d;
        }

        internal List<double> GenerateSeries(double firstNumber, double growthRate, int size)
        {
            var list = new List<double>();
            var index = 1;

            if (size > 0)
            {
                list.Add(firstNumber);
            }

            while (list.Count < size)
            {
                var nextSeq = Round(growthRate * (Exponent(firstNumber, index)));

                if (IsUnique(list, nextSeq))
                {
                    list.Add(nextSeq);
                }

                index += 1;
            }

            return list;
         }

        internal double Round(double nextSeq)
        {
            return Math.Ceiling(nextSeq * 4) / 4.0d;
        }

        internal bool IsUnique(List<double> list, double nextSeq)
        {
            return !list.Any(n => n == nextSeq);
        }

        internal double GrowthRate(double firstNumber, double y)
        {
            var result = (TwoPercent(y) / 25) / (firstNumber);

            return Math.Ceiling(result * 2) / 2;
        }

        internal double FirstNumber(double number)
        {
            var result = ((0.5 * Exponent(number, 2)) + (30 * number) + 10) / 25;

            return result;
        }

        private double TwoPercent(double input)
        {
            return input * 0.02d;
        }

        private double Exponent(double number, int numberOfTimes)
        {
            return Math.Pow(number, numberOfTimes);
        }
    }
}
