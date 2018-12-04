namespace BloomFilter.Utilities
{
    public interface IHashFunction<T>
    {
        int ComputeHash(T value);
    }
}
