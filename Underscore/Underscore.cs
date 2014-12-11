namespace Underscore
{
    using System;

    public static class Underscore
    {
        public static Action Once(Action action)
        {
            return new OnceAction(action);
        }
    }
}