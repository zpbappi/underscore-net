namespace Underscore.Specs.Functions.Debounce
{
    using System;
    using System.Threading;

    using Machine.Specifications;

    using NSubstitute;
    using global::Underscore;

    [Tags("_.Debounce()")]
    [Subject("Generic version to leading debounce test")]
    public class GenericLeadingDebounceTest
    {
        Establish context = () =>
        {
            data = Substitute.For<IDebounceTestData>();
            action = Underscore.Debounce<int, int>(data.DoSomethingWithNumbers, 100, true);
        };

        Because of = () =>
        {
            action(1, 11);
            action(2, 22);
            action(3, 33);
        };

        It should_call_action_once_with_first_params =
            () => data.Received(1).DoSomethingWithNumbers(Arg.Is<int>(x => x == 1), Arg.Is<int>(y => y == 11));

        private static IDebounceTestData data;

        private static Action<int, int> action;
    }
}