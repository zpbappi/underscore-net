namespace Underscore.Core
{
    using System;

    internal interface IExecutionCallback
    {
        void Execute(Guid callerId, params object[] args);

        void ExecuteWithoutNotification(params object[] args);
    }
}