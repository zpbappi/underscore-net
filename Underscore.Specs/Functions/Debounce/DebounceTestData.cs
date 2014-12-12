namespace Underscore.Specs.Functions.Debounce
{
    public interface IDebounceTestData
    {
        void DoSomething();

        void DoAnotherThing();

        void DoSomethingWithNumbers(int x, int y);
    }

    public class DebounceTestData : IDebounceTestData
    {
        public void DoSomething()
        {
            // do nothing
        }

        public void DoAnotherThing()
        {
            // do nothing
        }

        public void DoSomethingWithNumbers(int x, int y)
        {
            // do nothing
        }
    }
}