namespace UnderscoreNet.Core.Generic
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    internal class ExecutionContext<T> : IExecutionWrapper
    {
        private readonly Delegate action;

        private readonly IExecutionBehavior executionBehavior;

        internal ExecutionContext(Delegate action, IExecutionBehavior executionBehavior)
        {
            this.action = action;
            this.executionBehavior = executionBehavior;
            executionBehavior.SetWrapper(this);
        }

        internal Action<T> Wrapper
        {
            get
            {
                return t => this.WrapperFunction(t);
            }
        }

        public void Execute(Guid callerId, params object[] args)
        {
            this.ExecuteInternal(callerId, args);
        }

        public void ExecuteWithoutNotification(params object[] args)
        {
            this.ExecuteInternalWithoutNotification(args);
        }

        protected void WrapperFunction(params object[] args)
        {
            var callerId = Guid.NewGuid();

            this.executionBehavior.NotifyWrapperCalling(callerId, args);

            try
            {
                if (this.executionBehavior.CanExecute)
                {
                    this.ExecuteInternal(callerId, args);
                }
            }
            finally
            {
                this.executionBehavior.NotifyWrapperCalled(callerId, args);
            }
        }

        private void ExecuteInternal(Guid callerId, params object[] args)
        {
            this.executionBehavior.NotifyExecuting(callerId, args);
            try
            {
                this.ExecuteInternalWithoutNotification(args);
            }
            finally
            {
                this.executionBehavior.NotifyExecuted(callerId, args);
            }
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

    internal class ExecutionContext<T1, T2, T3, T4> : ExecutionContext<T1>
    {
        internal ExecutionContext(Delegate action, IExecutionBehavior executionBehavior)
            : base(action, executionBehavior)
        {
        }

        internal new Action<T1, T2, T3, T4> Wrapper
        {
            get
            {
                return (t1, t2, t3, t4) => this.WrapperFunction(t1, t2, t3, t4);
            }
        }
    }
}