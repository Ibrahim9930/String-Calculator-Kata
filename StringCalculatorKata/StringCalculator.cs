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
            var numberStrings = ExtractNumberStrings(sequence);
            return AddNumbersInAStringSequence(numberStrings);
        }

        private static string[] ExtractNumberStrings(string sequence)
        {
            return sequence.Split(',','\n');
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