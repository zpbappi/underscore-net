namespace Underscore
{
    using System;

    internal class OnceAction : UnderscoreActionExecutionBase
    {
        private bool canExecute;
        public OnceAction(Action action)
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
}