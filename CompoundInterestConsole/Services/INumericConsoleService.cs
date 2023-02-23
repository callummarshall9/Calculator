namespace CompoundInterestConsole.Services
{
    public interface INumericConsoleService
    {
        decimal GetNumber(decimal lowerBound, decimal upperBound);
        void WriteMessage(string message);
    }
}
