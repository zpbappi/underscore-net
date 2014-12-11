namespace Underscore.Core.Generic
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    internal class ExecutionContext<T> : IExecutionCallback
    {
        private readonly Delegate action;

        private readonly IExecutionBehavior executionBehavior;

        internal ExecutionContext(Delegate action, IExecutionBehavior executionBehavior)
        {
            this.action = action;
            this.executionBehavior = executionBehavior;
        }

        internal Action<T> Wrapper
        {
            get
            {
                return t => this.WrapperFunction(t);
            }
        }

        public void Execute(params object[] args)
        {
            this.ExecuteInternal(args);
        }

        public void ExecuteWithoutNotification(params object[] args)
        {
            this.ExecuteInternalWithoutNotification(args);
        }

        protected void WrapperFunction(params object[] args)
        {
            this.executionBehavior.NotifyWrapperCalling(args);

            if (this.executionBehavior.CanExecute)
            {
                this.ExecuteInternal(args);
            }

            this.executionBehavior.NotifyWrapperCalled(args);
        }

        private void ExecuteInternal(params object[] args)
        {
            this.executionBehavior.NotifyExecuting(args);
            this.ExecuteInternalWithoutNotification(args);
            this.executionBehavior.NotifyExecuted(args);
        }

        private void ExecuteInternalWithoutNotification(params object[] args)
        {
            this.action.DynamicInvoke(args);
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "These generic classes better stay in the same file, until we find another way of removing them completely.")]
    internal class ExecutionContext<T1, T2> : ExecutionContext<T1>
    {
        internal ExecutionContext(Delegate action, IExecutionBehavior executionBehavior)
            : base(action, executionBehavior)
        {
        }

        internal new Action<T1, T2> Wrapper
        {
            get
            {
                return (t1, t2) => this.WrapperFunction(t1, t2);
            }
        }
    }

    internal class ExecutionContext<T1, T2, T3> : ExecutionContext<T1>
    {
        internal ExecutionContext(Delegate action, IExecutionBehavior executionBehavior)
            : base(action, executionBehavior)
        {
        }

        internal new Action<T1, T2, T3> Wrapper
        {
            get
            {
                return (t1, t2, t3) => this.WrapperFunction(t1, t2, t3);
            }
        }
    }
}