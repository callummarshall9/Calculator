using Calculator.Services;
using System;
using System.Linq;

namespace Calculator.TestsNUnit
{
    public partial class MathServiceTests
    {
        private readonly IMathService mathService;

        public MathServiceTests() 
        {
            mathService = new MathService();
        }

        public decimal[] RandomDecimals()
            => Enumerable.Range(1, 1000)
                .Select(_ => RandomDecimal())
                .ToArray();

        public decimal RandomDecimal()
            => (decimal)(new Random().NextDouble() * 100.0);
    }
}
