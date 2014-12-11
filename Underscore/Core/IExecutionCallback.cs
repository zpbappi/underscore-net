namespace Underscore.Core
{
    internal interface IExecutionCallback
    {
        void Execute(params object[] args);

        void ExecuteWithoutNotification(params object[] args);
    }
}