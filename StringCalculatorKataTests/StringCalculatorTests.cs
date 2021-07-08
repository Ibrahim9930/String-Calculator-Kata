using System;
using FluentAssertions;
using StringCalculatorKata;
using Xunit;

namespace StringCalculatorKataTests
{
    public class StringCalculatorShould
    {
        [Theory]
        [InlineData("",0)]
        [InlineData("1",1)]
        [InlineData("1,2",3)]
        public void StringCalculatorAdd_EmptyString_Zero(string numberSequence, int summation)
        {

            StringCalculator stringCalculator = new StringCalculator();
            int summationResult = stringCalculator.Add(numberSequence);
            summationResult.Should().Be(summation);

        }
        

    }


}