namespace Underscore
{
    using System;

    using global::Underscore.Core;
    using global::Underscore.Functions.Debounce;
    using global::Underscore.Core.Generic;

    /// <summary>
    /// Registration for Debounce() methods
    /// </summary>
    public static partial class Underscore
    {
        public static Action Debounce(Action action, double wait, bool immediate = false)
        {
            var behavior = immediate ? (IExecutionBehavior)null : new TrailingDebounceBehavior(wait);
            return new ExecutionContext(action, behavior).Wrapper;
        }

        public static Action<T> Debounce<T>(Action<T> action, double wait, bool immediate = false)
        {
            var behavior = immediate ? (IExecutionBehavior)null : new TrailingDebounceBehavior(wait);
            return new ExecutionContext<T>(action, behavior).Wrapper;
        }

        public static Action<T1, T2> Debounce<T1, T2>(Action<T1, T2> action, double wait, bool immediate = false)
        {
            var behavior = immediate ? (IExecutionBehavior)null : new TrailingDebounceBehavior(wait);
            return new ExecutionContext<T1, T2>(action, behavior).Wrapper;
        }

        public static Action<T1, T2, T3> Debounce<T1, T2, T3>(Action<T1, T2, T3> action, double wait, bool immediate = false)
        {
            var behavior = immediate ? (IExecutionBehavior)null : new TrailingDebounceBehavior(wait);
            return new ExecutionContext<T1, T2, T3>(action, behavior).Wrapper;
        }

        public static Action<T1, T2, T3, T4> Debounce<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, double wait, bool immediate = false)
        {
            var behavior = immediate ? (IExecutionBehavior)null : new TrailingDebounceBehavior(wait);
            return new ExecutionContext<T1, T2, T3, T4>(action, behavior).Wrapper;
        }
    }
}