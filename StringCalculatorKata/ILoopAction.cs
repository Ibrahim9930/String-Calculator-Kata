using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public interface ILoopAction
    {
        public void DoAction(ref int currentElement);
    }

    public class SummationLoopAction : ILoopAction
    {
        public int Summation { get; set; } = 0;

        public void DoAction(ref int currentElement)
        {
            Summation += currentElement;
        }
    }

    public class CheckForNegativesLoopAction : ILoopAction
    {
        private readonly StringCalculator _stringCalculator;
        private readonly List<int> _negativeNumbers;
        private const string ExceptionMessageIntro = "negatives are not allowed";

        public CheckForNegativesLoopAction(StringCalculator stringCalculator)
        {
            _stringCalculator = stringCalculator;
            _negativeNumbers = new List<int>();
            stringCalculator.DoneAddLoop +=
                () =>
                {
                    if (_negativeNumbers.Count > 0)
                        throw new Exception($"{ExceptionMessageIntro} : {string.Join(", ", _negativeNumbers)}");
                };
        }

        public void DoAction(ref int currentElement)
        {
            if (currentElement < 0)
                _negativeNumbers.Add(currentElement);
        }
    }

    public class CheckForBigNumbers : ILoopAction
    {
        private readonly StringCalculator _stringCalculator;

        public CheckForBigNumbers(StringCalculator stringCalculator)
        {
            _stringCalculator = stringCalculator;
        }

        public void DoAction(ref int currentElement)
        {
            if (currentElement >= _stringCalculator.BigNumberThreshold)
            {
                currentElement = 0;
            }
        }
    }
}