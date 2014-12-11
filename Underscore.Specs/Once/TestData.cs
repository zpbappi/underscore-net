namespace Underscore.Specs.Once
{
    using System.Collections.Generic;

    public interface ITestData
    {
        void DoSomething();

        void Method1(int a);

        void Method2(int a, string s);

        void Method3(string a, double d, IEnumerable<string> names);
    }

    public class TestData : ITestData
    {
        public void DoSomething()
        {
            // do nothing
        }

        public void Method1(int a)
        {
            // do nothing
        }

        public void Method2(int a, string s)
        {
            // do nothing
        }

        public void Method3(string a, double d, IEnumerable<string> names)
        {
            // do nothing
        }
    }
}