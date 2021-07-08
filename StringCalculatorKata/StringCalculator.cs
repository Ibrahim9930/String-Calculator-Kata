using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string sequence)
        {
            if (!sequence.Any())
                return 0;
            var numberStrings = ExtractNumberStrings(ref sequence);
            return AddNumbersInAStringSequence(numberStrings);
        }

        private static string[] ExtractNumberStrings(ref string sequence)
        {
            Regex separatorRegex = new Regex("(?<=(//)).*");

            var firstLine = sequence.Split("\n").FirstOrDefault();
            string pattern;
            if (separatorRegex.IsMatch(firstLine))
            {
                var match = separatorRegex.Match(firstLine);
                pattern = match.Value;
                sequence = sequence.Remove(0, firstLine.Length + 1);
            }
            else
            {
                pattern = ",|\n";
            }
            return Regex.Split(sequence,pattern);
        }

        private static int AddNumbersInAStringSequence(string[] numberStrings)
        {
            int sum = 0;
            foreach (var numberString in numberStrings)
            {
                sum += ParseInt(numberString);
            }

            return sum;
        }

        private static int ParseInt(string numberString)
        {
            return int.Parse(numberString);
        }
    }
}