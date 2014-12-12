namespace Underscore.Specs.Functions.Debounce
{
    using System;

    using Machine.Specifications;
    using NSubstitute;

    using UnderscoreNet;

    [Tags("_.Debounce()")]
    [Subject("Non-Generic version to leading debounce test")]
    public class LeadingDebounceTest
    {
        Establish context = () =>
        {
            data = Substitute.For<IDebounceTestData>();
            action = Underscore.Debounce(data.DoSomething, 100, true);
        };

        Because of = () =>
        {
            action();
            action();
            action();
        };

        It should_call_action_once_immediately = () => data.Received(1).DoSomething();

        private static IDebounceTestData data;

        private static Action action;
    }
}