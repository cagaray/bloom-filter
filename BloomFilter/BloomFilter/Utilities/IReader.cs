using System.Threading.Tasks;

namespace BloomFilter.Utilities
{
    public interface IReader
    {
        Task<string> GetContentsFromFileAsync();
    }
}