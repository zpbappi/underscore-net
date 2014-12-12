namespace Underscore.Functions.Debounce
{
    using System;
    using System.Threading;
    using System.Timers;

    using global::Underscore.Core;

    using Timer = System.Timers.Timer;

    internal class TrailingDebounceBehavior : Disposable, IExecutionBehavior
    {
        private readonly Mutex executingMutex;

        private IExecutionWrapper wrapper;

        private readonly Timer timer;

        private object[] parameters;

        private Guid callerId;

        private bool isDisposed;

        public TrailingDebounceBehavior(double wait)
        {
            this.executingMutex = new Mutex();
            this.timer = new Timer(wait) { AutoReset = false };
            this.timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.executingMutex.WaitOne();
            ((Timer)sender).Stop();
            this.wrapper.Execute(this.callerId, this.parameters);
        }

        public bool CanExecute
        {
            get
            {
                // never executed by calling the wrapper
                return false;
            }
        }

        public void NotifyWrapperCalling(Guid callerId, params object[] args)
        {
            this.executingMutex.WaitOne();
            this.callerId = callerId;
            this.parameters = args;
            this.executingMutex.ReleaseMutex();
        }

        public void NotifyWrapperCalled(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuting(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
            this.executingMutex.ReleaseMutex();
            this.timer.Start();
        }

        public void SetWrapper(IExecutionWrapper executionWrapper)
        {
            this.wrapper = executionWrapper;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }
            this.isDisposed = true;

            if (this.executingMutex != null)
            {
                this.executingMutex.Dispose();
            }

            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Dispose();
            }
        }
    }
}