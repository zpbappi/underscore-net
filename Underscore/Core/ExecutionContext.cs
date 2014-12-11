namespace Underscore.Core
{
    using System;

    public class ExecutionContext : IExecutionCallback
    {
        private readonly Action action;

        private readonly IExecutionBehavior executionBehavior;

        internal ExecutionContext(Action action, IExecutionBehavior executionBehavior)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
            this.executionBehavior = executionBehavior;
        }

        internal Action Wrapper
        {
            get
            {
                return this.WrapperFunction;
            }
        }

        public void Execute(params object[] args)
        {
            this.ExecuteInternal();
        }

        public void ExecuteWithoutNotification(params object[] args)
        {
            this.ExecuteInternal(true);
        }

        private void WrapperFunction()
        {
            this.executionBehavior.NotifyWrapperCalling();

            if (this.executionBehavior.CanExecute)
            {
                this.ExecuteInternal();
            }

            this.executionBehavior.NotifyWrapperCalled();
        }

        private void ExecuteInternal(bool suppressNotification = false)
        {
            if (!suppressNotification)
            {
                this.executionBehavior.NotifyExecuting();
            }

            this.action();

            if (suppressNotification)
            {
                this.executionBehavior.NotifyExecuted(); 
            }
        }
    }
}