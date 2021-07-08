namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string sequence)
        {
            if (sequence.Length == 0)
                return 0;
            
            return int.Parse(sequence);
        }
    }
}