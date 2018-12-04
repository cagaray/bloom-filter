namespace BloomFilter
{
    public interface IDictionary<T>
    {
        void AddItem(T item);
        bool CheckItem(T item);
        bool IsEmpty();
    }
}
