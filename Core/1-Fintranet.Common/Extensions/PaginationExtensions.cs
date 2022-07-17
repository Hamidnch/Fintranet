namespace _1_Fintranet.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            var enumerable = source as T[] ?? source.ToArray();
            return enumerable.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<T> ToPaged<T>(this IEnumerable<T> source, int page, int pageSize, out int rowCount)
        {
            var enumerable = source as T[] ?? source.ToArray();
            rowCount = enumerable.Count();
            return enumerable.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}