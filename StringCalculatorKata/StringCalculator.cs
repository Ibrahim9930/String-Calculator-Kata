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

        public int Add(string sequence)
        {
            if (!sequence.Any())
                return 0;
            var numberStrings = ExtractNumberStrings(sequence);
            return AddNumbersInAStringSequence(numberStrings);
        }

        private static string[] ExtractNumberStrings(string sequence)
        {
            string separator = GetSeparator(sequence);
            RemoveCustomDelimiterSpecification(ref sequence);
            return Regex.Split(sequence, separator);
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

        private static int AddNumbersInAStringSequence(string[] numberStrings)
        {
            int sum = 0;
            string illegalNumbers = "";
            foreach (var numberString in numberStrings)
            {
                int parsedNumber = ParseInt(numberString);
                if (parsedNumber < 0)
                    illegalNumbers += $"{numberString}, ";
                sum += ParseInt(numberString);
            }

            if (illegalNumbers.Length != 0)
                throw new Exception(
                    $"negatives are not allowed : {illegalNumbers.TrimEnd(',',' ')}");
            return sum;
        }

        private static int ParseInt(string numberString)
        {
            return int.Parse(numberString);
        }
    }
}