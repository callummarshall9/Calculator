using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Calculator.Services
{
    public class MathService : IMathService
    {
        public IEnumerable<(decimal lowerBound, decimal upperBound, decimal frequencyDensity, IEnumerable<decimal> numbers)> ComputeHistogram(IEnumerable<decimal> numbers, decimal upperBound, int numberOfBins)
        {
            decimal increment = upperBound / numberOfBins;

            for(int i = 0; i < numberOfBins; i++)
            {
                decimal lowerHistogramBound = i * increment;
                decimal upperHistogramBound = (i+1) * increment;

                int frequency = 0;
                List<decimal> classEntries = new List<decimal>();

                for(int j = 0; j < numbers.Count(); j++)
                {
                    if (numbers.ElementAt(j) > lowerHistogramBound && numbers.ElementAt(j) <= upperHistogramBound)
                    {
                        frequency++;
                        classEntries.Add(numbers.ElementAt(j));
                    }
                }

                yield return (lowerHistogramBound, upperHistogramBound, frequency / increment, classEntries.OrderBy(r => r));
            }
        }

        public decimal ComputeSTDDev(IEnumerable<decimal> numbers)
        {
            decimal mean = ComputeMean(numbers);
            decimal variance = numbers.Select(n => (n - mean) * (n - mean)).Sum() / (numbers.Count() - 1);

            return ComputeSqrt(variance);
        }

        public decimal ComputeMean(IEnumerable<decimal> numbers)
        {
            decimal sum = 0.0m;
            foreach(var number in numbers)
                sum += number;

            return sum / numbers.Count();
        } 

        public decimal ComputeSqrt(decimal number)
        {
            if (number < 0)
                throw new ValidationException("Number must be positive");

            decimal tolerance = 1e-20m;
            decimal x_n = number;
            decimal previous_x_n = (decimal)(new Random().NextDouble());

            while(Math.Abs(x_n - previous_x_n) > tolerance) {
                previous_x_n = x_n;
                x_n = 0.5m * (previous_x_n + (number / previous_x_n));
            }

            return x_n;
        }
    }
}