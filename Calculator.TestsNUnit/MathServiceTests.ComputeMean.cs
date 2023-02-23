using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Calculator.TestsNUnit
{
    public partial class MathServiceTests
    {
        [Test]
        public void ShouldComputeAverage()
        {
            //given
            decimal[] input = RandomDecimals();
            decimal expectedAverage = input.Average();

            //when
            decimal actualAverage = mathService.ComputeMean(input);

            //then
            actualAverage.Should().Be(expectedAverage);
        }
    }
}
