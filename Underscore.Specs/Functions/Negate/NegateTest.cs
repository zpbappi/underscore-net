namespace Underscore.Specs.Functions.Negate
{
    using System;

    using Machine.Specifications;

    using UnderscoreNet;

    [Tags("_.Negate()")]
    [Subject("Testing _.Negate")]
    public class NegateTest
    {
        Establish context = () =>
            {
                data = new TestData();
                amIUnhappy = Underscore.Negate(data.AreYouHappy);
                oddDetector = Underscore.Negate<int>(data.IsEven);
            };

        private Because of = () =>
            {
                isUnhappy = amIUnhappy();
                isThreeOdd = oddDetector(3);
            };

        It should_say_i_am_not_unhappy = () => isUnhappy.ShouldBeFalse();

        It should_detect_3_as_odd_number = () => isThreeOdd.ShouldBeTrue();

        private static ITestData data;
        private static Func<bool> amIUnhappy;
        private static Func<int, bool> oddDetector;
        private static bool isUnhappy, isThreeOdd;
    }

    [Tags("_.Negate()")]
    [Subject("Testing _.Negate for double negation")]
    public class DoubleNegationTest
    {
        Establish context = () =>
        {
            data = new TestData();
            evenDetector = Underscore.Negate(Underscore.Negate<int>(data.IsEven));
        };

        Because of = () => twoIsEven = evenDetector(2);

        It should_detect_two_as_even = () => twoIsEven.ShouldBeTrue();

        private static ITestData data;
        private static Func<int, bool> evenDetector;
        private static bool twoIsEven;
    }
}