using CompoundInterestConsole.Brokers;
using System.ComponentModel.DataAnnotations;

namespace CompoundInterestConsole.Services
{
    public class NumericConsoleService : INumericConsoleService
    {
        private readonly IConsoleBroker broker;

        public NumericConsoleService(IConsoleBroker broker)
        {
            this.broker = broker;
        }

        public decimal GetNumber(decimal lowerBound, decimal upperBound)
        {
            string input = broker.ReadLine();

            if (input == "done")
                return -1;

            if (!decimal.TryParse(input, out _))
                throw new ValidationException("Must be a valid number");

            decimal number = decimal.Parse(input);

            if (number < lowerBound)
                throw new ValidationException($"Number must be greater than {lowerBound}");

            if (number > upperBound)
                throw new ValidationException($"Number must be less than {upperBound}");


            return number;
        }

        public void WriteMessage(string message)
            => broker.WriteLine(message);
    }
}
