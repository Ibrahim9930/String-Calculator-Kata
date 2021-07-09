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
        public void StringCalculatorAdd_EmptySequenceString_Zero()
        {
            int summationResult = _stringCalculator.Add("");
            summationResult.Should().Be(0);
        }

        [Fact]
        public void StringCalculatorAdd_SingleNumberSequenceString_ParsedNumber()
        {
            int summationResult = _stringCalculator.Add("1");
            summationResult.Should().Be(1);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        public void StringCalculatorAdd_MultiNumberSequence_SequenceSummation(string numberSequence, int summation)
        {
            int summationResult = _stringCalculator.Add(numberSequence);
            summationResult.Should().Be(summation);
        }

        [Fact]
        public void StringCalculatorAdd_NewLineSeperatedSequenceString_SequenceSummation()
        {
            int summationResult = _stringCalculator.Add("1\n2,3");
            summationResult.Should().Be(6);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        [InlineData("//separator\n1separator2separator3", 6)]
        public void StringCalculatorAdd_CustomDelimiterSeperatedSequenceString_SequenceSummation(string numberSequence,
            int result)
        {
            int summationResult = _stringCalculator.Add(numberSequence);
            summationResult.Should().Be(result);
        }

        [Theory]
        [InlineData("1,2,-3","negatives are not allowed : -3")]
        [InlineData("1,-2,3","negatives are not allowed : -2")]
        [InlineData("-1,2,3","negatives are not allowed : -1")]
        [InlineData("-1,-2,3","negatives are not allowed : -1, -2")]
        [InlineData("-1,-2,-3","negatives are not allowed : -1, -2, -3")]
        [InlineData("//|\n-1|-2|-3","negatives are not allowed : -1, -2, -3")]
        public void StringCalculatorAdd_NegativeNumbersInSequence_ThrowsException(string numberSequence,
            string exceptionMessage)
        {
            Action addAction = ()=>  _stringCalculator.Add(numberSequence);
            addAction.Should().Throw<Exception>().Which.Message.Should().Be(exceptionMessage);
        }
        
        [Fact]
        public void StringCalculatorAdd_NegativeZeroInSequence_AcceptsSequence()
        {
            Action addAction = ()=>  _stringCalculator.Add("-0,1,2");
            addAction.Should().NotThrow<Exception>();
        }
        

    }
}