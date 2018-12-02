using System;
namespace BloomFilter.Utilities
{
    public class DotNetHashFunction<T> : IHashFunc<T>
    {
        public DotNetHashFunction()
        {
        }

        public int ComputeHash(T value)
        {
            return value.GetHashCode();
        }
    }
}
