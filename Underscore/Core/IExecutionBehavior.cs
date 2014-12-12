namespace UnderscoreNet.Core
{
    using System;

    internal interface IExecutionBehavior
    {
        bool CanExecute { get; }

        void NotifyWrapperCalling(Guid callerId, params object[] args);

        void NotifyWrapperCalled(Guid callerId, params object[] args);

        void NotifyExecuting(Guid callerId, params object[] args);

        void NotifyExecuted(Guid callerId, params object[] args);

        void SetWrapper(IExecutionWrapper executionWrapper);
    }
}