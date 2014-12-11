namespace Underscore.Specs.Once
{
    using System;

    using Machine.Specifications;

    using NSubstitute;

    [Tags("_.Once")]
    [Subject(typeof(Underscore))]
    public class OnceTest
    {
        Establish context = () =>
            {
                data = Substitute.For<ITestData>();
                
                action = Underscore.Once(data.DoSomething);
            };

        Because i_call_action_multiple_times = () =>
            {
                action();
                action();
                action();
                action();
                action();
            };

        It should_receive_call_only_once = () => data.Received(1).DoSomething();

        private static Action action;

        private static ITestData data;
    }
}