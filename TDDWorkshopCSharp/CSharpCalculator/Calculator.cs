using System.Net;

namespace CSharpCalculator
{
    public class Calculator
    {
        private readonly IInputService _inputService;
        public Calculator(IInputService inputService) 
        {
            _inputService = inputService;
        }
        public int Add()
        {
            
            string param = GetInput();

            ArgumentNullException.ThrowIfNull(param);

            if (param == string.Empty)
            {
                return 0;
            }
            else
            {
                var numbers = param.Split(",");
                return SumNumbers(numbers);
            }
        }
        private string GetInput(int retryCount = 0)
        {
            try
            {
                 return  _inputService.GetInput();
            }
            catch (WebException)
            {
                if (retryCount <= 3)
                {
                    retryCount++;
                    return GetInput(retryCount);
                }

                throw;
            }
        }

        private static int SumNumbers(string[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(numbers[i], out int val))
                {
                    checked
                    {
                        sum += val;
                    }
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