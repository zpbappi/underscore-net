namespace UnderscoreNet.Functions.Debounce
{
    using System;
    using System.Timers;

    using UnderscoreNet.Core;

    internal class LeadingDebounceBehavior : Disposable, IExecutionBehavior
    {
        private readonly object mutext;

        private readonly Timer timer;

        private bool isDisposed;

        private bool canExecute;

        public LeadingDebounceBehavior(double wait)
        {
            this.canExecute = true;
            this.mutext = new object();
            this.timer = new Timer(wait) { AutoReset = false };
            this.timer.Elapsed += this.TimerElapsed;
        }

        public bool CanExecute
        {
            get
            {
                if (!this.canExecute)
                {
                    return false;
                }

                lock (this.mutext)
                {
                    if (!this.canExecute)
                    {
                        return false;
                    }

                    this.canExecute = false;
                    return true;
                }
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
            this.timer.Start();
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
        }

        public void SetWrapper(IExecutionWrapper executionWrapper)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            this.isDisposed = true;

            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Dispose();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (this.mutext)
            {
                this.canExecute = true;
            }

            ((Timer)sender).Stop();
        }
    }
}