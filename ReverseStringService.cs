using Microsoft.Extensions.Configuration;

namespace ReverseString
{
    public class ReverseStringService : IReverseStringService
    {
        private readonly IConfiguration _configuration;
        public ReverseStringService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ReverseString()
        {
            var inputString = Environment.GetEnvironmentVariable("inputString");

            Console.WriteLine($"Input string - {inputString}");

            if (inputString == null)
            {
                Console.WriteLine($"inputString cannont be empty!");
                return;
            }

            string outputString = "";
            for (int i = inputString.Length; i > 0; i--)
            {
                outputString += inputString[i - 1];
            }

            File.AppendAllText("ReverseStringText.txt", outputString + Environment.NewLine);
            Console.WriteLine($"Your reversed string - {outputString}\n");
        }
    }
}
