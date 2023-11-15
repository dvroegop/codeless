namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;
            var num = numbers.Split(',');
            
            int sum = 0;
            foreach (var item in num)
            {
                if (int.TryParse(item, out int number))
                {
                    sum += number;
                }
                else
                {
                    throw new InvalidCastException($" either {item} is not a valid int number or its value is out of range");
                }
            }

            return sum;
        }
    }
}