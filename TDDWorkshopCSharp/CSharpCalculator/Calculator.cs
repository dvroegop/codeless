namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;
            var num = numbers.Split(',', StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            foreach (var item in num)
            {
                sum += int.Parse(item);
            }

            return sum;
        }
    }
}