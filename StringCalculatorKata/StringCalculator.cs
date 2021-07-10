using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private static readonly Regex CustomDelimiterRegex = new Regex("(?<=(//)).*");
        private const string DefaultDelimiter = ",|\n";
        public event Action DoneAddLoop;
        public int BigNumberThreshold { get; set; } = 1000;
        private Dictionary<string, ILoopAction> _loopActions;

        public StringCalculator()
        {
            _loopActions = new Dictionary<string, ILoopAction>()
            {
                {"Big Number Check", new CheckForBigNumbers(this)},
                {"Check For Negatives", new CheckForNegativesLoopAction(this)},
                {"Summation", new SummationLoopAction()},
            };
        }

        public int Add(string sequence)
        {
            if (!sequence.Any())
                return 0;
            var numberStrings = ExtractNumberStrings(sequence);
            LoopOverSequencesAndApplyActions(numberStrings);
            return (_loopActions["Summation"] as SummationLoopAction).Summation;
        }

        private void LoopOverSequencesAndApplyActions(List<string> numberStrings)
        {
            foreach (var numberString in numberStrings)
            {
                int parsedNumber = ParseInt(numberString);
                foreach (var loopAction in _loopActions)
                {
                    loopAction.Value.DoAction(ref parsedNumber);
                }
            }

            OnDoneAddLoop();
        }

        private void OnDoneAddLoop()
        {
            if (DoneAddLoop != null)
                DoneAddLoop();
        }
        
        private static List<string> ExtractNumberStrings(string sequence)
        {
            string separator = GetSeparator(sequence);
            RemoveCustomDelimiterSpecification(ref sequence);
            return Regex.Split(sequence, separator).ToList();
        }

        private static string GetSeparator(string sequence)
        {
            if (HasCustomDelimiter(sequence))
            {
                return GetCustomDelimiter(sequence);
            }

            return DefaultDelimiter;
        }

        private static bool HasCustomDelimiter(string sequence)
        {
            var firstLine = GetFirstLine(sequence);

            return CustomDelimiterRegex.IsMatch(firstLine);
        }

        private static string GetCustomDelimiter(string sequence)
        {
            var firstLine = GetFirstLine(sequence);
            string customDelimiter = CustomDelimiterRegex.Match(firstLine).Value;
            return Regex.Escape(customDelimiter);
        }

        private static string GetFirstLine(string sequence)
        {
            return sequence.Split("\n").FirstOrDefault();
        }

        private static void RemoveCustomDelimiterSpecification(ref string sequence)
        {
            if (HasCustomDelimiter(sequence))
            {
                var firstLine = GetFirstLine(sequence);
                sequence = sequence.Remove(0, firstLine.Length + 1);
            }
        }
        
        private static int ParseInt(string numberString)
        {
            return int.Parse(numberString);
        }
    }
}