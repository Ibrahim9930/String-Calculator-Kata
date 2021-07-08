using System;
using FluentAssertions;
using StringCalculatorKata;
using Xunit;

namespace StringCalculatorKataTests
{
    public class StringCalculatorShould
    {
        [Fact]
        public void StringCalculatorAdd_EmptyString_Zero()
        {

            StringCalculator stringCalculator = new StringCalculator();
            int summationResult = stringCalculator.Add("");
            summationResult.Should().Be(0);

        }
        
    }


}