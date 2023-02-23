using System.Collections.Generic;

namespace Calculator.Services
{
    public interface IMathService
    {
        decimal ComputeSTDDev(IEnumerable<decimal> numbers);
        decimal ComputeMean(IEnumerable<decimal> numbers);
        decimal ComputeSqrt(decimal number);
        IEnumerable<(decimal lowerBound, decimal upperBound, decimal frequencyDensity, IEnumerable<decimal> numbers)> ComputeHistogram(IEnumerable<decimal> numbers, decimal upperBound, int numberOfBins);
    }
}
