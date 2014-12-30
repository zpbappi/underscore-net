namespace UnderscoreNet
{
    using System;

    using UnderscoreNet.Core;
    using UnderscoreNet.Core.Generic;
    using UnderscoreNet.Functions.Throttle;

    /// <summary>
    /// Registration for Throttle() methods
    /// </summary>
    public static partial class Underscore
    {
        public static Action Throttle(Action action, double wait, bool leading = true, bool trailing = false)
        {
            return new ExecutionContext(action, new ThrottleBehavior(wait, leading, trailing)).Wrapper;
        }

        public static Action<T> Throttle<T>(Action<T> action, double wait, bool leading = true, bool trailing = true)
        {
            return new ExecutionContext<T>(action, new ThrottleBehavior(wait, leading, trailing)).Wrapper;
        }

        public static Action<T1, T2> Throttle<T1, T2>(
            Action<T1, T2> action,
            double wait,
            bool leading = true,
            bool trailing = true)
        {
            return new ExecutionContext<T1, T2>(action, new ThrottleBehavior(wait, leading, trailing)).Wrapper;
        }

        public static Action<T1, T2, T3> Throttle<T1, T2, T3>(
            Action<T1, T2, T3> action,
            double wait,
            bool leading = true,
            bool trailing = true)
        {
            return new ExecutionContext<T1, T2, T3>(action, new ThrottleBehavior(wait, leading, trailing)).Wrapper;
        }

        public static Action<T1, T2, T3, T4> Throttle<T1, T2, T3, T4>(
            Action<T1, T2, T3, T4> action,
            double wait,
            bool leading = true,
            bool trailing = true)
        {
            return new ExecutionContext<T1, T2, T3, T4>(action, new ThrottleBehavior(wait, leading, trailing)).Wrapper;
        }
    }
}