namespace CoinChangeProblem
{
    public interface ICoinChangeCalculatorManager
    {
        Change DoTransaction(string timeIn, string timeOut, float payment);
    }
}