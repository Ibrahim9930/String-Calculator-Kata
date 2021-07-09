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
            RemoveBigNumbers(ref numberStrings);
            CheckForNegativeNumbers(numberStrings);
            return AddNumbersInAStringSequence(numberStrings);
        }

        private static void RemoveBigNumbers(ref List<string> numberStrings)
        {
            numberStrings = numberStrings.Where(e => ParseInt(e) < 1000).ToList();
        }

        private void CheckForNegativeNumbers(List<string> numberStrings)
        {
            string illegalNumbers = "";
            foreach (var numberString in numberStrings)
            {
                int parsedNumber = ParseInt(numberString);
                if (parsedNumber < 0)
                    illegalNumbers += $"{numberString}, ";
            }

            if (illegalNumbers.Length != 0)
                throw new Exception(
                    $"negatives are not allowed : {RemoveTrailingCommaAndWhiteSpace(illegalNumbers)}");
        }

        private static string RemoveTrailingCommaAndWhiteSpace(string illegalNumbers)
        {
            return illegalNumbers.TrimEnd(',', ' ');
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

        private static int AddNumbersInAStringSequence(List<string> numberStrings)
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
                    $"negatives are not allowed : {illegalNumbers.TrimEnd(',', ' ')}");
            return sum;
        }

        private static int ParseInt(string numberString)
        {
            return int.Parse(numberString);
        }
    }
}