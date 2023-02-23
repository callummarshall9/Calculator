using CompoundInterestConsole.Brokers;
using CompoundInterestConsole.Services;

namespace CompoundInterestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orchestrationService = new InterestOrchestrationService(new MathService(), new NumericConsoleService(new ConsoleBroker()));

            orchestrationService.CalculateCompoundInterest();
        }
    }
}