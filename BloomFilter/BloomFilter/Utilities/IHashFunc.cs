using System;
namespace BloomFilter.Utilities
{
    public interface IHashFunc<T>
    {
        int ComputeHash(T value);
    }
}
