using System.ComponentModel.DataAnnotations;

namespace CompoundInterestConsole.Services
{
    public class InterestOrchestrationService
    {
        private readonly IMathService mathService;
        private readonly INumericConsoleService numericConsoleService;

        public InterestOrchestrationService(IMathService mathService, INumericConsoleService numericConsoleService)
        {
            this.mathService = mathService;
            this.numericConsoleService = numericConsoleService;
        }

        public void CalculateCompoundInterest()
        {
            numericConsoleService.WriteMessage("Write a value");
            decimal value = GetInput();

            //compound decrease is < 0 interest rate
            numericConsoleService.WriteMessage("Write a value for interest rate");
            decimal interestRate = GetInput(-100);

            numericConsoleService.WriteMessage("Write a value for years");
            decimal years = GetInput();

            decimal finalValue = mathService.CalculateCompoundInterest(value, interestRate, years);

            numericConsoleService.WriteMessage($"Final value is {finalValue}, a net of {finalValue - value}");
        }


        private decimal GetInput(decimal lowerBound = 0)
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    decimal number = numericConsoleService.GetNumber(lowerBound, 100);
                    return number;
                }
                catch (ValidationException ex)
                {
                    numericConsoleService.WriteMessage(ex.Message);
                }
            }

            return -1;
        }
    }
}
