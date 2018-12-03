namespace BloomFilter
{
    public interface IDict<T>
    {
        void AddItem(T item);
        bool CheckItem(T item);
        bool IsEmpty();
    }
}
