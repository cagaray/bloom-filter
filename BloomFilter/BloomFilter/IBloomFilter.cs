namespace BloomFilter
{
    public interface IBloomFilter<T>
    {
        void AddItem(T item);
        bool CheckItem(T item);
    }
}
