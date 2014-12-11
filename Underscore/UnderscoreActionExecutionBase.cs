namespace Underscore
{
    using System;

    public abstract class UnderscoreActionExecutionBase
    {
        private readonly Action action;

        public static implicit operator Action(UnderscoreActionExecutionBase instance)
        {
            return instance.Wrapper;
        }

        internal UnderscoreActionExecutionBase(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
        }

        protected abstract bool CanExecute { get; }

        protected virtual void Executing()
        {
        }

        protected virtual void Executed()
        {
        }

        protected virtual void WrapperCalling()
        {
        }

        protected virtual void WrapperCalled()
        {
        }

        internal Action Wrapper
        {
            get
            {
                return this.WrapperFunction;
            }
        }

        protected void WrapperFunction()
        {
            this.WrapperCalling();

            if (this.CanExecute)
            {
                this.Executing();
                this.Execute();
                this.Executed();
            }

            this.WrapperCalled();
        }

        protected void Execute()
        {
            this.action();
        }
    }
}