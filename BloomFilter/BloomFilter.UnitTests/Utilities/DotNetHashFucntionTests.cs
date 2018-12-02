using System;
using BloomFilter.Utilities;
using Xunit;

namespace BloomFilter.UnitTests.Utilities
{
    public class DotNetHashFucntionTests
    {
        [Fact]
        public void ComputeHash_HashOffoo_ReturnInt()
        {
            string foo = "foo";
            DotNetHashFunction<string> hashFunction = new DotNetHashFunction<string>();

            var hash = hashFunction.ComputeHash(foo);

            Assert.IsType<int>(hash);
        }
    }
}
