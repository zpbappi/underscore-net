namespace Underscore.Specs.Functions.Negate
{
    public interface ITestData
    {
        bool IsEven(int n);

        bool AreYouHappy();
    }

    public class TestData : ITestData
    {
        public bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        public bool AreYouHappy()
        {
            return true;
        }
    }
}