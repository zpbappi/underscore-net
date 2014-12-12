namespace UnderscoreNet.Core
{
    using System;

    internal interface IExecutionWrapper
    {
        void Execute(Guid callerId, params object[] args);

        void ExecuteWithoutNotification(params object[] args);
    }
}