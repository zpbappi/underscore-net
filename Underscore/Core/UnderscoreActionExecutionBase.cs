namespace Underscore.Core
{
    using System;

    public class UnderscoreActionExecutionBase : IExecutionCallback
    {
        private readonly Action action;

        private readonly IExecutionBehavior executionBehavior;

        public static implicit operator Action(UnderscoreActionExecutionBase instance)
        {
            return instance.Wrapper;
        }

        internal UnderscoreActionExecutionBase(Action action, IExecutionBehavior executionBehavior)
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

        public void Execute(params object[] args)
        {
            this.ExecuteInternal();
        }

        public void ExecuteWithoutNotification(params object[] args)
        {
            this.ExecuteInternal(true);
        }
    }
}