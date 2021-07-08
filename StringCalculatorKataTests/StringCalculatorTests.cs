using System;
using FluentAssertions;
using StringCalculatorKata;
using Xunit;

namespace StringCalculatorKataTests
{
    public class StringCalculatorShould
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorShould()
        {
            _stringCalculator = new StringCalculator();

        }
        [Fact]

        public void StringCalculatorAdd_EmptyString_Zero()
        {
            int summationResult = _stringCalculator.Add("");
            summationResult.Should().Be(0);
        }

        [Fact]
        public void StringCalculatorAdd_SingleNumberString_ParsedNumber()
        {
            int summationResult = _stringCalculator.Add("1");
            summationResult.Should().Be(1);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        public void StringCalculatorAdd_MultiNumberString_NumberSummation(string numberSequence,int summation)
        {
            int summationResult = _stringCalculator.Add(numberSequence);
            summationResult.Should().Be(summation);
        }
        
        
    }


}