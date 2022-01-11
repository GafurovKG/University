namespace MyGenetics
{
    using System;
    using System.Collections.Generic;

    public static class MyBinarySearch<T>
        where T : IComparable<T>
    {
        public static int BinarySearch<T1>(IEnumerable<T1> values, T1 searchable)
            where T1 : IComparable<T1>
        {
            int center = values.Count() / 2;
            int border = values.Count();
            do
            {
                if (values.ElementAt(center).CompareTo(searchable) > 0)
                {
                    border = center;
                    center /= 2;
                }
                else if (values.ElementAt(center).CompareTo(searchable) < 0)
                {
                    center += (border - center) / 2;
                }
            }
            while (values.ElementAt(center).CompareTo(searchable) != 0);

            return center;
        }
    }
}