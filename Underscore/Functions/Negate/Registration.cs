namespace UnderscoreNet
{
    using System;

    public static partial class Underscore
    {
        public static Func<bool> Negate(Func<bool> func)
        {
            return () => !func();
        }

        public static Func<T, bool> Negate<T>(Func<T, bool> func)
        {
            return (val) => !func(val);
        }

        public static Func<T1, T2, bool> Negate<T1, T2>(Func<T1, T2, bool> func)
        {
            return (val1, val2) => !func(val1, val2);
        }

        public static Func<T1, T2, T3, bool> Negate<T1, T2, T3>(Func<T1, T2, T3, bool> func)
        {
            return (val1, val2, val3) => !func(val1, val2, val3);
        }

        public static Func<T1, T2, T3, T4, bool> Negate<T1, T2, T3, T4>(Func<T1, T2, T3, T4, bool> func)
        {
            return (val1, val2, val3, val4) => !func(val1, val2, val3, val4);
        }
    }
}