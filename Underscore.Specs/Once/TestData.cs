namespace Underscore.Specs.Once
{
    using System;

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