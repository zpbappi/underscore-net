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

        public void Execute(Guid callerId, params object[] args)
        {
            this.ExecuteInternal(callerId);
        }

        public void ExecuteWithoutNotification(params object[] args)
        {
            this.ExecuteInternal(Guid.Empty, true);
        }

        private void WrapperFunction()
        {
            var callerId = Guid.NewGuid();

            this.executionBehavior.NotifyWrapperCalling(callerId);

            if (this.executionBehavior.CanExecute)
            {
                this.ExecuteInternal(callerId);
            }

            this.executionBehavior.NotifyWrapperCalled(callerId);
        }

        private void ExecuteInternal(Guid callerId, bool suppressNotification = false)
        {
            if (!suppressNotification)
            {
                this.executionBehavior.NotifyExecuting(callerId);
            }

            this.action();

            if (suppressNotification)
            {
                this.executionBehavior.NotifyExecuted(callerId); 
            }
        }
    }
}