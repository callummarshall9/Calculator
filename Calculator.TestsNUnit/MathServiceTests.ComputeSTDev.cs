using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Calculator.TestsNUnit
{
    public partial class MathServiceTests
    {
        [Test]
        public void ShouldComputeSTDevCorrectly()
        {
            //given
            decimal[] input = RandomDecimals();
            decimal expected = (decimal)MathNet.Numerics.Statistics.Statistics.StandardDeviation(input.Select(l => (double)l));

            //when
            decimal actual = mathService.ComputeSTDDev(input);
            //then

            Math.Round(actual, 13).Should().Be(Math.Round(expected, 13));
        }
        
    }
}
