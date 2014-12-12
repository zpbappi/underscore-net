namespace UnderscoreNet.Functions.Once
{
    using System;

    using UnderscoreNet.Core;

    internal class OnceBehavior : IExecutionBehavior
    {
        private int executed;

        public OnceBehavior()
        {
            this.executed = 0;
        }

        public bool CanExecute
        {
            get
            {
                return System.Threading.Interlocked.CompareExchange(ref this.executed, 1, 0) == 0;
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

        public void SetWrapper(IExecutionWrapper executionWrapper)
        {
        }
    }
}