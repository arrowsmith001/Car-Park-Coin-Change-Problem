namespace CoinChangeProblem
{
    public interface ICoinChangeClass
    {
        Change CalculateChange(float cost, float[] permittedCash);
    }
}