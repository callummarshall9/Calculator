using FluentAssertions;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.TestsNUnit
{
    public partial class MathServiceTests
    {
        [Test]
        public void ShouldComputeSqrt()
        {
            //given
            decimal input = RandomDecimal();
            decimal expected = (decimal)Math.Sqrt((double)input);

            //when
            decimal actual = mathService.ComputeSqrt(input);

            //then
            Math.Round(actual, 13).Should().Be(Math.Round(expected, 13));
        }

        [Test]
        public void ShouldThrowValidationExceptionIfNegative()
        {
            //given
            decimal input = -RandomDecimal();

            //when
            TestDelegate action = () => mathService.ComputeSqrt(input);

            //then
            Assert.Throws<ValidationException>(action);
        }
    }
}
