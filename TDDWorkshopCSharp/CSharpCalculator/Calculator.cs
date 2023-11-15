
namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            ArgumentNullException.ThrowIfNull(input, nameof(input));

            if (input == string.Empty) return 0;
            return 1;
        }
    }
}