namespace Underscore.Specs.Functions.Throttle
{
    using System;
    using System.Threading;

    using Machine.Specifications;

    using NSubstitute;

    using UnderscoreNet;

    [Tags("_.Throttle()")]
    [Subject("Testing non-generic version on _.Throttle)")]
    public class ThrottleTest
    {
        Establish context = () =>
        {
            data = Substitute.For<ITestData>();

            action = Underscore.Throttle(data.DoSomething, 500);
        };

        Because i_call_action_multiple_times = () =>
        {
            action();
            action();
            action();
            action();
            action();
        };

        It should_be_called_once = () => data.Received(1).DoSomething();

        private static Action action;

        private static ITestData data;
    }

    [Tags("_.Throttle()")]
    [Subject("Testing non-generic version on _.Throttle for multiple calls with wait)")]
    public class ThrottleTestWithWait
    {
        Establish context = () =>
        {
            data = Substitute.For<ITestData>();

            action = Underscore.Throttle(data.DoSomething, 500);
            action2 = Underscore.Throttle(data.DoSomethingElse, 100);
        };

        Because i_call_actions_multiple_times = () =>
        {
            action();
            action2();
            action();
            action2();
            Thread.Sleep(150);
            action();
            action2();
            Thread.Sleep(600);
            action();
            action2();
            Thread.Sleep(150);
            action();
            action2();
        };

        It should_call_action_twice = () => data.Received(2).DoSomething();

        It should_call_action2_four_times = () => data.Received(4).DoSomethingElse();

        private static Action action, action2;

        private static ITestData data;
    }
}