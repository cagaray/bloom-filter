using System;
using BloomFilter.Utilities;
using Xunit;

namespace BloomFilter.UnitTests.Utilities
{
    public class HashFunctionDotNetTests
    {
        [Fact]
        public void ComputeHash_HashOffoo_ReturnInt()
        {
            string foo = "foo";
            HashFunctionDotNet<string> hashFunction = new HashFunctionDotNet<string>();

            var hash = hashFunction.ComputeHash(foo);

            Assert.IsType<int>(hash);
        }

        [Fact]
        public void ComputeHash_HashOffooTwice_ReturnSameResult()
        {
            string foo1 = "foo";
            string foo2 = "foo";
            HashFunctionDotNet<string> hashFunction = new HashFunctionDotNet<string>();

            var hash1 = hashFunction.ComputeHash(foo1);
            var hash2 = hashFunction.ComputeHash(foo2);

            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void ComputeHash_HashOfEmpty_ReturnInt()
        {
            string foo = "";
            HashFunctionDotNet<string> hashFunction = new HashFunctionDotNet<string>();

            var hash = hashFunction.ComputeHash(foo);

            Assert.IsType<int>(hash);
        }

        [Fact]
        public void ComputeHash_HashOfNull_ThrowException()
        {
            string foo = null;
            HashFunctionDotNet<string> hashFunction = new HashFunctionDotNet<string>();

            Action act = () => hashFunction.ComputeHash(foo);

            Assert.Throws<NullReferenceException>(act);
        }
    }
}
