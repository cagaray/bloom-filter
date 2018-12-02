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

        [Fact]
        public void ComputeHash_HashOffooTwice_ReturnSameResult()
        {
            string foo1 = "foo";
            string foo2 = "foo";
            JenkinsHashFunction<string> hashFunction = new JenkinsHashFunction<string>();

            int hash1 = hashFunction.ComputeHash(foo1);
            int hash2 = hashFunction.ComputeHash(foo2);

            Assert.Equal(hash1, hash2);
        }
    }
}
