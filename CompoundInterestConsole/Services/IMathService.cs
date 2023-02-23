namespace CompoundInterestConsole.Services
{
    public interface IMathService
    {
        decimal CalculateCompoundInterest(decimal value, decimal interest, decimal years);
    }
}