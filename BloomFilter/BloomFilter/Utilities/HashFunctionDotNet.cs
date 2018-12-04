namespace BloomFilter.Utilities
{
    public class HashFunctionDotNet<T> : IHashFunction<T>
    {
        public int ComputeHash(T value)
        {
            return value.GetHashCode();
        }
    }
}
