using System;
using BloomFilter.Utilities;
using Xunit;

namespace BloomFilter.UnitTests.Utilities
{
    public class HashFunctionJenkinsTests
    {
        [Fact]
        public void ComputeHash_HashOffoo_ReturnInt()
        {
            string foo = "foo";
            HashFunctionJenkins<string> hashFunction = new HashFunctionJenkins<string>();

            int hash = hashFunction.ComputeHash(foo);

            Assert.IsType<int>(hash);
        }

        [Fact]
        public void ComputeHash_HashOffooTwice_ReturnSameResult()
        {
            string foo1 = "foo";
            string foo2 = "foo";
            HashFunctionJenkins<string> hashFunction = new HashFunctionJenkins<string>();

            int hash1 = hashFunction.ComputeHash(foo1);
            int hash2 = hashFunction.ComputeHash(foo2);

            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void ComputeHash_HashOfEmpty_ReturnInt()
        {
            string foo = "";
            HashFunctionJenkins<string> hashFunction = new HashFunctionJenkins<string>();

            int hash = hashFunction.ComputeHash(foo);

            Assert.IsType<int>(hash);
        }

        [Fact]
        public void ComputeHash_HashOfNull_ThrowException()
        {
            string foo = null;
            HashFunctionJenkins<string> hashFunction = new HashFunctionJenkins<string>();

            Action act = () => hashFunction.ComputeHash(foo);

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
