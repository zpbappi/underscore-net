namespace Underscore.Specs.Functions.Debounce
{
    using System;
    using System.Threading;

    using Machine.Specifications;

    using NSubstitute;
    using UnderscoreNet;

    [Tags("_.Debounce()")]
    [Subject("Non-Generic version to trailling debounce test")]
    public class TrailingDebounceTest
    {
        Establish context = () =>
            {
                data = Substitute.For<IDebounceTestData>();
                action = Underscore.Debounce(data.DoSomething, 100);
            };

        Because of = () =>
            {
                action();
                action();
                action();
                Thread.Sleep(150);
            };

        It should_call_action_once = () => data.Received(1).DoSomething();

        private static IDebounceTestData data;

        private static Action action;
    }
}