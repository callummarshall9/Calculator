namespace Calculator.Services
{
    public interface IStatisticsOrchestrationService
    {
        void CalculateHistograms();
        void CalculateMean();
        void CalculateSqrt();
        void CalculateSTDev();
    }
}