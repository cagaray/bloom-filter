using System;
using BloomFilter.Utilities;
using Xunit;

namespace BloomFilter.UnitTests.Utilities
{
    public class JenkinsHashFunctionTests
    {
        [Fact]
        public void ComputeHash_HashOffoo_ReturnCorrectResult()
        {
            string foo = "foo";
            JenkinsHashFunction<string> hashFunction = new JenkinsHashFunction<string>();

            int hash = hashFunction.ComputeHash(foo);

            Assert.Equal(1127866192, hash);
        }
    }
}
