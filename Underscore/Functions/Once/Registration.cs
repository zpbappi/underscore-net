namespace Underscore.Functions.Once
{
    using System;

    using global::Underscore.Core;
    using global::Underscore.Core.Generic;

    /// <summary>
    /// Registration for Once() methods
    /// </summary>
    public static partial class Underscore
    {
        public static Action Once(Action action)
        {
            return new ExecutionContext(action, new OnceBehavior()).Wrapper;
        }

        public static Action<T> Once<T>(Action<T> action)
        {
            return new ExecutionContext<T>(action, new OnceBehavior()).Wrapper;
        }

        public static Action<T1, T2> Once<T1, T2>(Action<T1, T2> action)
        {
            return new ExecutionContext<T1, T2>(action, new OnceBehavior()).Wrapper;
        }

        public static Action<T1, T2, T3> Once<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return new ExecutionContext<T1, T2, T3>(action, new OnceBehavior()).Wrapper;
        }

        public static Action<T1, T2, T3, T4> Once<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            return new ExecutionContext<T1, T2, T3, T4>(action, new OnceBehavior()).Wrapper;
        }
    }
}