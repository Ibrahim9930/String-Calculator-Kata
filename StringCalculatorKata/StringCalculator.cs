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
            switch (numberStrings.Length)
            {
                case 1:
                    return ParseInt(numberStrings[0]);
                case 2:
                    return ParseInt(numberStrings[0]) + ParseInt(numberStrings[1]);
                default: return -1;
            }
        }

        private static int ParseInt(string numberString)
        {
            return int.Parse(numberString);
        }
    }
}