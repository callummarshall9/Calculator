using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Calculator.Services
{
    public class StatisticsOrchestrationService : IStatisticsOrchestrationService
    {
        private readonly INumericConsoleService numericConsoleService;
        private readonly IMathService mathService;

        public StatisticsOrchestrationService(INumericConsoleService numericConsoleService, IMathService mathService)
        {
            this.numericConsoleService = numericConsoleService;
            this.mathService = mathService;
        }

        public void CalculateHistograms()
        {
            numericConsoleService.WriteMessage($"Enter numbers one at a time, write 'done' to finish your set");

            List<decimal> numbers = new List<decimal>();

            decimal number = 0;

            while (number != -1)
            {
                number = GetInput();

                //-1 indicates user wrote done
                if (number == -1)
                    break;

                numbers.Add(number);
            }

            IEnumerable<(decimal lowerBound, decimal upperBound, decimal frequencyDensity, IEnumerable<decimal> numbers)> histogramData = mathService.ComputeHistogram(numbers, 100, 10);

            numericConsoleService.WriteMessage("lowerBound < x <= upperBound: frequency density [applicable numbers]");

            foreach (var entry in histogramData)
            {
                numericConsoleService.WriteMessage($"{entry.lowerBound} < x <= {entry.upperBound}: {entry.frequencyDensity} [{string.Join(",", entry.numbers.Select(r => r.ToString()))}]");
            }
        }

        public void CalculateMean()
        {
            numericConsoleService.WriteMessage($"Enter numbers one at a time, write 'done' to finish your set");

            List<decimal> numbers = new List<decimal>();

            decimal number = 0;

            while (number != -1)
            {
                number = GetInput();

                //-1 indicates user wrote done
                if (number == -1)
                    break;

                numbers.Add(number);
            }

            numericConsoleService.WriteMessage($"Mean is {mathService.ComputeMean(numbers)}");
        }

        public void CalculateSTDev()
        {
            numericConsoleService.WriteMessage($"Enter numbers one at a time, write 'done' to finish your set");

            List<decimal> numbers = new List<decimal>();

            decimal number = 0;

            while (number != -1)
            {
                number = GetInput();

                //-1 indicates user wrote done
                if (number == -1)
                    break;

                numbers.Add(number);
            }

            numericConsoleService.WriteMessage($"STDev is {mathService.ComputeSTDDev(numbers)}");
        }

        public void CalculateSqrt()
        {
            numericConsoleService.WriteMessage($"Enter a number");

            decimal number = GetInput();

            if (number == -1)
                return;

            numericConsoleService.WriteMessage($"Square root is {mathService.ComputeSqrt(number)}");
        }

        private decimal GetInput()
        {
            bool success = false;

            while (!success)
            {
                try
                {
                    decimal number = numericConsoleService.GetNumber(0, 100);
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
