using System.IO;
using System.Threading.Tasks;

namespace BloomFilter.Utilities
{
    public class TxtReaderFromFileSystem : IReaderFromFileSystem
    {
        public TxtReaderFromFileSystem()
        {
        }

        public async Task<string> GetContentsFromFileAsync(string path)
        {
            using (var reader = File.OpenText(path))
                return await reader.ReadToEndAsync();
        }
    }
}
