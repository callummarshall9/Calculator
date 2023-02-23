using Calculator.Brokers;
using Calculator.Services;
using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu");

            Console.WriteLine("1) Mean Calculation");
            Console.WriteLine("2) STDev Calculation");
            Console.WriteLine("3) Square Root Calculation (accurate to 13 decimal places)");
            Console.WriteLine("4) Histogram Calculation");

            var input = Console.ReadLine();

            var orchestrationService = new StatisticsOrchestrationService(new NumericConsoleService(new ConsoleBroker()),
                new MathService());

            if (input == "1")
                orchestrationService.CalculateMean();

            if (input == "2")
                orchestrationService.CalculateSTDev();

            if (input == "3")
                orchestrationService.CalculateSqrt();

            if (input == "4")
                orchestrationService.CalculateHistograms();

        }

    }
}