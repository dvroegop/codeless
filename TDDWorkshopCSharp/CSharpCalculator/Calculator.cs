
namespace CSharpCalculator
{
    public class Calculator
    {
        private readonly IService service;

        public Calculator(IService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public int Add()
        {
            string input = GetInputFromService();

            int returnValue;

            ArgumentNullException.ThrowIfNull(input, nameof(input));

            if (input == string.Empty) return 0;

            string[] values = input.Split(',');
            try
            {
                int[] intValues = Array.ConvertAll(values, int.Parse);
                long sum = SumValues(intValues);

                returnValue = Convert.ToInt32(sum);

            }
            catch (System.FormatException ex)
            {
                throw new InvalidOperationException();
            }
            catch (OverflowException ex)
            {
                throw new ArgumentOutOfRangeException();
            }

            return returnValue;
        }

        private string GetInputFromService()
        {
            int callNr = 0;

            while (true)
            {
                try
                {
                    return service.GetInputValue();
                }
                catch (Exception)
                {
                    callNr++;
                    if (callNr == 4)
                    {
                        throw new Exception("3 retries allowed");
                    }
                }
            }
        }

        private static long SumValues(int[] intValues)
        {
            long sum = 0;

            foreach (int intValue in intValues)
            {
                sum += intValue;
            }

            return sum;
        }
    }
}