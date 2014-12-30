namespace UnderscoreNet.Functions.Throttle
{
    using System;
    using System.Threading;
    using System.Timers;

    using Microsoft.Win32;

    using UnderscoreNet.Core;

    using Timer = System.Timers.Timer;

    internal class ThrottleBehavior : IExecutionBehavior
    {
        private readonly object leadingMutext;
        private readonly Timer throttlingExecutionTimer;
        private readonly Mutex trailingMutext;

        private readonly bool leading;
        private readonly bool trailing;
        private IExecutionWrapper wrapper;
        
        private Guid? trailingCallerId;
        private object[] trailingParameters;
        private System.Threading.ExecutionContext trailingExecContext;

        private bool canExecuteLeadingCall;

        public ThrottleBehavior(double wait, bool leading, bool trailing)
        {
            this.leading = leading;
            this.trailing = trailing;
            this.leadingMutext = new object();
            this.trailingExecContext = null;

            this.canExecuteLeadingCall = true;

            this.trailingMutext = new Mutex();
            this.throttlingExecutionTimer = new Timer { AutoReset = false, Interval = wait, Enabled = false };
            this.throttlingExecutionTimer.Elapsed += this.ThrottlingExecutionTimerElapsed;

        }

        public bool CanExecute
        {
            get
            {
                if (!this.leading)
                {
                    return false;
                }

                if (!this.canExecuteLeadingCall)
                {
                    return false;
                }

                lock (this.leadingMutext)
                {
                    if (!this.canExecuteLeadingCall)
                    {
                        return false;
                    }

                    this.canExecuteLeadingCall = false;
                    return true;
                }
            }
        }

        public void NotifyWrapperCalling(Guid callerId, params object[] args)
        {
            if (!this.trailing)
            {
                return;
            }

            this.trailingMutext.WaitOne();
            this.trailingCallerId = callerId;
            this.trailingParameters = args;
            if (this.trailingExecContext != null)
            {
                this.trailingExecContext.Dispose();
            }

            this.trailingExecContext = System.Threading.ExecutionContext.Capture();
            this.trailingMutext.ReleaseMutex();
            if (!this.throttlingExecutionTimer.Enabled)
            {
                this.throttlingExecutionTimer.Start();
            }
        }

        public void NotifyWrapperCalled(Guid callerId, params object[] args)
        {   
        }

        public void NotifyExecuting(Guid callerId, params object[] args)
        {
        }

        public void NotifyExecuted(Guid callerId, params object[] args)
        {
            if (!this.leading && !this.trailing)
            {
                return;
            }

            this.throttlingExecutionTimer.Start();
        }

        public void SetWrapper(IExecutionWrapper executionWrapper)
        {
            this.wrapper = executionWrapper;
        }

        private void ThrottlingExecutionTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
            timer.Stop();

            if (this.trailing && this.trailingCallerId.HasValue)
            {
                this.trailingMutext.WaitOne();
                using (this.trailingExecContext)
                {
                    System.Threading.ExecutionContext.Run(
                        this.trailingExecContext,
                        state => this.wrapper.Execute(this.trailingCallerId.Value, this.trailingParameters),
                        null);
                }

                this.trailingExecContext = null;
                this.trailingCallerId = null;
                this.trailingParameters = null;
                this.trailingMutext.ReleaseMutex();
            }
            else if (this.leading)
            {
                lock (this.leadingMutext)
                {
                    this.canExecuteLeadingCall = true;
                }
            }
        }
    }
}