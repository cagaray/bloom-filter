using System.Threading.Tasks;

namespace BloomFilter
{
    public interface ISpellChecker
    {
        bool CheckWordInDictionary(string word);
        bool IsEmptyDictionary();
        Task LoadDataFromPath();
    }
}