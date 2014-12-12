namespace Underscore.Core
{
    using System;

    public abstract class Disposable : IDisposable
    {
        ~Disposable()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected abstract void Dispose(bool disposing);
    }
}