using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string sequence)
        {
            if (!sequence.Any())
                return 0;
            var numberStrings = sequence.Split(',');
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