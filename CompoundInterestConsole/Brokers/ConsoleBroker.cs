namespace CompoundInterestConsole.Brokers
{
    public class ConsoleBroker : IConsoleBroker
    {
        public string ReadLine()
            => Console.ReadLine();

        public void WriteLine(string message)
            => Console.WriteLine(message);
    }
}
