namespace Underscore.Specs.Functions.Debounce
{
    using System;
    using System.Threading;

    using Machine.Specifications;

    using NSubstitute;
    using global::Underscore;

    [Tags("_.Debounce()")]
    [Subject("Generic version to trailling debounce test")]
    public class GenericTrailingDebounceTest
    {
        Establish context = () =>
        {
            data = Substitute.For<IDebounceTestData>();
            action = Underscore.Debounce<int, int>(data.DoSomethingWithNumbers, 100);
        };

        Because of = () =>
        {
            action(1, 11);
            action(2, 22);
            action(3, 33);
            Thread.Sleep(150);
        };

        It should_call_do_something_once_with_last_params =
            () => data.Received(1).DoSomethingWithNumbers(Arg.Is<int>(x => x == 3), Arg.Is<int>(y => y == 33));

        private static IDebounceTestData data;

        private static Action<int, int> action;
    }
}