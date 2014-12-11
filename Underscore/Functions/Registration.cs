namespace Underscore
{
    using System;

    using global::Underscore.Core;
    using global::Underscore.Core.Generic;
    using global::Underscore.Functions;

    public static partial class Underscore
    {
        public static Action Once(Action action)
        {
            return new UnderscoreActionExecutionBase(action, new OnceExecutionBehavior());
        }

        public static Action<T> Once<T>(Action<T> action)
        {
            return new GenericUnderscoreExecutionBase<T>(action, new OnceExecutionBehavior()).Wrapper;
        }

        public static Action<T1, T2> Once<T1, T2>(Action<T1, T2> action)
        {
            return new GenericUnderscoreExecutionBase<T1, T2>(action, new OnceExecutionBehavior()).Wrapper;
        }

        public static Action<T1, T2, T3> Once<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            return new GenericUnderscoreExecutionBase<T1, T2, T3>(action, new OnceExecutionBehavior()).Wrapper;
        }
    }
}