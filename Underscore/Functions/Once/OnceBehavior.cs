namespace Underscore.Functions.Once
{
    using global::Underscore.Core;

    internal class OnceBehavior : IExecutionBehavior
    {
        public OnceBehavior()
        {
            this.CanExecute = true;
        }

        public bool CanExecute { get; private set; }

        public void NotifyWrapperCalling(params object[] args)
        {
        }

        public void NotifyWrapperCalled(params object[] args)
        {
        }

        public void NotifyExecuting(params object[] args)
        {
            this.CanExecute = false;
        }

        public void NotifyExecuted(params object[] args)
        {
        }
    }
}