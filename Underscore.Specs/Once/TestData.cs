namespace Underscore.Specs.Once
{
    public interface ITestData
    {
        void DoSomething();
    }

    public class TestData : ITestData
    {
        public void DoSomething()
        {
            //do nothing
        }
    }
}