using System.Threading.Tasks;

namespace BloomFilter.Utilities
{
    public interface IReaderFromFileSystem
    {
        Task<string> GetContentsFromFileAsync(string path);
    }
}