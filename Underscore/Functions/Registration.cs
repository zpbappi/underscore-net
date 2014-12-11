namespace Underscore
{
    using System;

    using global::Underscore.Functions;

    public static partial class Underscore
    {
        public static Action Once(Action action)
        {
            return new Once(action);
        }

        //public static Action<T> Once<T>(Action<T> action)
        //{
            
        //}
    }
}