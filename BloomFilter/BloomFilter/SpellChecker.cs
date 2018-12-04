using System.Threading.Tasks;
using BloomFilter.Utilities;

namespace BloomFilter
{
    public class SpellChecker : ISpellChecker
    {
        private IReader _reader;
        private IDictionary<string> _dictionary;

        public SpellChecker(IReader reader, IDictionary<string> dictionary)
        {
            this._reader = reader;
            this._dictionary = dictionary;
        }

        public async Task LoadDataFromPath()
        {
            string fileContents = await _reader.GetContentsFromFileAsync();
            if (fileContents != null && fileContents != "")
            {
                foreach (string word in fileContents.Split("\n"))
                {
                    await Task.Run(() => _dictionary.AddItem(word));
                }
            }
        }

        public bool IsEmptyDictionary()
        {
            return _dictionary.IsEmpty();
        }

        public bool CheckWordInDictionary(string word)
        {
            return _dictionary.CheckItem(word);
        }
    }
}
