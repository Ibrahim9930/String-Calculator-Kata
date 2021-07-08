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

        [Fact]
        public void StringCalculatorAdd_OneNumber_ParsedNumber()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int summationResult = stringCalculator.Add("1");
            summationResult.Should().Be(1);
        }
        
        [Fact]
        public void StringCalculatorAdd_TwoNumbersNumber_TheirSummation()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int summationResult = stringCalculator.Add("1,2");
            summationResult.Should().Be(3);
        }

    }


}