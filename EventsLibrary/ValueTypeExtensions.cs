using System;

namespace EventsLibrary
{
    public static class ValueTypeExtensions
    {
        public static TValue Clamp<TValue>(this TValue value, TValue minValue, TValue maxValue) where TValue : struct, IComparable<TValue>
        {
            if (value.CompareTo(minValue) <= 0)
            {
                return minValue;
            }

            if (value.CompareTo(maxValue) >= 0)
            {
                return maxValue;
            }

            return value;
        }
    }
}
