namespace Underscore.Core
{
    internal interface IExecutionBehavior
    {
        bool CanExecute { get; }

        void NotifyWrapperCalling(params object[] args);

        void NotifyWrapperCalled(params object[] args);

        void NotifyExecuting(params object[] args);

        void NotifyExecuted(params object[] args);
    }
}