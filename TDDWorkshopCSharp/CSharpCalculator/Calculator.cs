
namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            int returnValue;
            ArgumentNullException.ThrowIfNull(input, nameof(input));

            if (input == string.Empty) return 0;
            string[] values = input.Split(',');
            try
            {
                int[] intValues = Array.ConvertAll(values, int.Parse);
                returnValue = intValues.Sum();
            }
            catch (System.FormatException ex)
            {
                throw new InvalidOperationException();
            }

            return returnValue;
        }
    }
}