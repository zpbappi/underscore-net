namespace Underscore.Functions.Once
{
    using System;

    using global::Underscore.Core;

    internal class OnceBehavior : IExecutionBehavior
    {
        private readonly object mutext;

        private bool canExecute;

        public OnceBehavior()
        {
            this.canExecute = true;
            this.mutext = new object();
        }

        public bool CanExecute
        {
            get
            {
                if (!this.canExecute)
                {
                    return false;
                }

                lock (this.mutext)
                {
                    if (!this.canExecute)
                    {
                        return false;
                    }

                    this.canExecute = false;
                    return true;
                }
            }
        }

        public void NotifyWrapperCalling(Guid callerId, params object[] args)
        {
        }

        public void NotifyWrapperCalled(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuting(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
        }
    }
}