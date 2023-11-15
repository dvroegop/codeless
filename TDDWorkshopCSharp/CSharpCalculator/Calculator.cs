namespace CSharpCalculator
{
    public class Calculator
    {
        public int Add(string param)
        {
            try
            {
                if (string.IsNullOrEmpty(param))
                {
                    return 0;
                }
                else
                {
                    return param.Split(",").Select(a => int.Parse(a)).Sum();
                }
            }
            catch (Exception ex)
            {
                throw new UnSupportedArgumentsException();
            }
        }
    }
}