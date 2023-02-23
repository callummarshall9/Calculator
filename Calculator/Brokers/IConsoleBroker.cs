namespace Calculator.Brokers
{
    public interface IConsoleBroker
    {
        string ReadLine();
        void WriteLine(string message);
    }
}
