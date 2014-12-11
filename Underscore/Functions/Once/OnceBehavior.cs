namespace Underscore.Functions.Once
{
    using System;

    using global::Underscore.Core;

    internal class OnceBehavior : IExecutionBehavior
    {
        public OnceBehavior()
        {
            this.CanExecute = true;
        }

        public bool CanExecute { get; private set; }

        public void NotifyWrapperCalling(Guid callerId, params object[] args)
        {
        }

        public void NotifyWrapperCalled(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuting(Guid callerId, params object[] args)
        {
            this.CanExecute = false;
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
        }
    }
}