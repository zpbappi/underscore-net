﻿namespace Underscore.Specs.Functions.Debounce
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
                action1 = Underscore.Debounce(data.DoSomething, 500);
                action2 = Underscore.Debounce(data.DoAnotherThing, 100);
            };

        Because of = () =>
            {
                action1();
                action2();
                action1();
                action2();
                action1();
                action2();
                
                Thread.Sleep(200);

                action1();
                action2();
                action1();
                action2();
                action1();
                action2();

                Thread.Sleep(600);
            };

        It should_call_action1_once = () => data.Received(1).DoSomething();

        It should_call_action2_twice = () => data.Received(2).DoAnotherThing();

        private static IDebounceTestData data;

        private static Action action1, action2;
    }
}