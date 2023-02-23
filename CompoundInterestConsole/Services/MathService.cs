namespace CompoundInterestConsole.Services
{
    public class MathService : IMathService
    {
        public decimal CalculateCompoundInterest(decimal value, decimal interest, decimal years)
            => value * (decimal)Math.Pow(1 + (double)interest / 100, (double)years);
    }
}
