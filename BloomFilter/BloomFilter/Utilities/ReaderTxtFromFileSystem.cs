using System.IO;
using System.Threading.Tasks;

namespace BloomFilter.Utilities
{
    public class ReaderTxtFromFileSystem : IReader
    {
        private readonly string _path;

        public ReaderTxtFromFileSystem(string path)
        {
            this._path = path;
        }

        public async Task<string> GetContentsFromFileAsync()
        {
            using (var reader = File.OpenText(_path))
                return await reader.ReadToEndAsync();
        }
    }
}
