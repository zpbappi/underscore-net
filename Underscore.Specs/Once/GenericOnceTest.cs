namespace Underscore.Specs.Once
{
    using System;
    using System.Collections.Generic;

    using Machine.Specifications;

    using NSubstitute;

    [Tags("_.Once()")]
    [Subject(typeof(Underscore), "Testing generic version of _.Once()")]
    public class GenericOnceTest
    {
        Establish context = () =>
        {
            data = Substitute.For<ITestData>();

            action1 = Underscore.Once<int>(data.Method1);
            action2 = Underscore.Once<int, string>(data.Method2);
            action3 = Underscore.Once<string, double, IEnumerable<string>>(data.Method3);
        };

        Because i_call_all_actions_multiple_times = () =>
            {
                action1(1);
                action1(2);
                action1(3);

                action2(1, "a");
                action2(2, "b");
                action2(3, "c");

                action3("a", 1f, new[] { "A" });
                action3("b", 2f, new[] { "B", "A" });
                action3("c", 2f, new[] { "C", "B", "A" });
            };

        It should_call_action1_only_once = () => data.Received(1).Method1(Arg.Any<int>());

        It should_call_action2_only_once = () => data.Received(1).Method2(Arg.Any<int>(), Arg.Any<string>());

        It should_call_action3_only_once = () => data.Received(1).Method3(Arg.Any<string>(), Arg.Any<double>(), Arg.Any<IEnumerable<string>>());

        private static Action<int> action1;

        private static Action<int, string> action2;

        private static Action<string, double, IEnumerable<string>> action3;

        private static ITestData data;
    }
}