namespace Underscore.Specs.Functions.Throttle
{
    using System.Collections.Generic;

    public interface ITestData
    {
        void DoSomething();

        void DoSomethingElse();

        void Method1(int a);

        void Method2(int a, string s);

        void Method3(string a, double d, IEnumerable<string> names);

        void Method4(int a, char b, string c, long d);
    }

    public class TestData : ITestData
    {
        public void DoSomething()
        {
            // do nothing
        }

        public void DoSomethingElse()
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

        public void Method4(int a, char b, string c, long d)
        {
            // do nothing
        }
    }
}