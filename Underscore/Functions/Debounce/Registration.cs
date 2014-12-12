namespace Underscore.Functions.Once
{
    using System;

    using global::Underscore.Core;
    using global::Underscore.Core.Generic;
    using global::Underscore.Functions.Debounce;

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
    }
}