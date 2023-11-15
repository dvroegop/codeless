namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string param)
        {
            ArgumentNullException.ThrowIfNull(param);

            if (param == string.Empty)
            {
                return 0;
            }
            else
            {
                var numbers = param.Split(",");
                switch (numbers.Length)
                {
                    case 1:
                        int sum;
                        if (int.TryParse(numbers[0], out sum))
                        {
                            return sum;
                        }
                        else
                        {
                            throw new UnSupportedArgumentsException();
                        }

                    case 2:
                        return SumNumbers(numbers);

                    default:
                        throw new UnSupportedArgumentsException();
                }
            }
        }

        private static int SumNumbers(string[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(numbers[i], out int val))
                {
                    sum += val;
                }
                else
                {
                    throw new UnSupportedArgumentsException();
                }
            }

            return sum;
        }
    }
}