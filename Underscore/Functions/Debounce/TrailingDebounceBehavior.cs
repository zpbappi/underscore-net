namespace UnderscoreNet.Functions.Debounce
{
    using System;
    using System.Threading;
    using System.Timers;

    using UnderscoreNet.Core;

    using Timer = System.Timers.Timer;

    internal class TrailingDebounceBehavior : Disposable, IExecutionBehavior
    {
        private readonly Mutex executingMutex;
        private readonly Timer timer;

        private Guid wrapperCallerId;
        private object[] parameters;

        private IExecutionWrapper wrapper;
        private bool isDisposed;
        private System.Threading.ExecutionContext execContext;

        public TrailingDebounceBehavior(double wait)
        {
            this.executingMutex = new Mutex();
            this.timer = new Timer(wait) { AutoReset = false };
            this.timer.Elapsed += this.TimerElapsed;
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
            this.timer.Stop();
            this.executingMutex.WaitOne();
            this.wrapperCallerId = callerId;
            this.parameters = args;
            if (this.execContext != null)
            {
                this.execContext.Dispose();
            }

            this.execContext = System.Threading.ExecutionContext.Capture();
        }

        public void NotifyWrapperCalled(Guid callerId, params object[] args)
        {
            this.executingMutex.ReleaseMutex();
            this.timer.Start();
        }

        public void NotifyExecuting(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
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

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.executingMutex.WaitOne();
            ((Timer)sender).Stop();
            using (this.execContext)
            {
                System.Threading.ExecutionContext.Run(
                    this.execContext,
                    state => this.wrapper.Execute(this.wrapperCallerId, this.parameters),
                    null);
            }

            this.execContext = null;
            this.executingMutex.ReleaseMutex();
        }
    }
}