namespace Underscore.Functions
{
    using global::Underscore.Core;

    internal class OnceExecutionBehavior : IExecutionBehavior
    {
        public OnceExecutionBehavior()
        {
            this.CanExecute = true;
        }

        public bool CanExecute { get; private set; }

        public void NotifyWrapperCalling(params object[] args)
        {
            //
        }

        public void NotifyWrapperCalled(params object[] args)
        {
            //
        }

        public void NotifyExecuting(params object[] args)
        {
            this.CanExecute = false;
        }

        public void NotifyExecuted(params object[] args)
        {
            //
        }
    }
}