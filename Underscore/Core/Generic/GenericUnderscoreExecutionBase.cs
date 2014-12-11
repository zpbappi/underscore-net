namespace Underscore.Core.Generic
{
    using System;

    internal abstract class GenericUnderscoreExecutionBase<T>
    {
        private readonly Delegate action;

        internal GenericUnderscoreExecutionBase(Delegate action)
        {
            this.action = action;
        }

        protected abstract bool CanExecute { get; }

        protected virtual void Executing(params object[] args)
        {
        }

        protected virtual void Executed(params object[] args)
        {
        }

        protected virtual void WrapperCalling(params object[] args)
        {
        }

        protected virtual void WrapperCalled(params object[] args)
        {
        }

        internal Action<T> Wrapper
        {
            get
            {
                return (t) => this.WrapperFunction(t);
            }
        }

        protected void WrapperFunction(params object[] args)
        {
            this.WrapperCalling(args);

            if (this.CanExecute)
            {
                this.Executing(args);
                this.Execute(args);
                this.Executed(args);
            }

            this.WrapperCalled();
        }

        private void Execute(params object[] args)
        {
            this.action.DynamicInvoke(args);
        }
    }

    internal abstract class GenericUnderscoreExecutionBase<T1, T2> : GenericUnderscoreExecutionBase<T1>
    {
        internal GenericUnderscoreExecutionBase(Delegate action)
            : base(action)
        {
            
        }

        internal new Action<T1, T2> Wrapper
        {
            get
            {
                return (t1, t2) => this.WrapperFunction(t1, t2);
            }
        }
    }

    internal abstract class GenericUnderscoreExecutionBase<T1, T2, T3> : GenericUnderscoreExecutionBase<T1>
    {
        internal GenericUnderscoreExecutionBase(Delegate action)
            : base(action)
        {

        }

        internal new Action<T1, T2, T3> Wrapper
        {
            get
            {
                return (t1, t2, t3) => this.WrapperFunction(t1, t2, t3);
            }
        }
    }
}