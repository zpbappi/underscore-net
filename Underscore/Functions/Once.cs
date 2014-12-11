namespace Underscore.Functions
{
    using System;

    using global::Underscore.Core;
    using global::Underscore.Core.Generic;

    internal class Once : UnderscoreActionExecutionBase
    {
        private bool canExecute;
        public Once(Action action)
            : base(action)
        {
            this.canExecute = true;
        }

        protected override bool CanExecute
        {
            get
            {
                return this.canExecute;
            }
        }

        protected override void Executing()
        {
            this.canExecute = false;
        }
    }

    internal class Once<T> : GenericUnderscoreExecutionBase<T>
    {

        public Once(Delegate action):base(action)
        {
            
        }

        protected override bool CanExecute
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}