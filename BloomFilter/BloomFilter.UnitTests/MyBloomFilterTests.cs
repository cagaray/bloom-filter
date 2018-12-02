using System;
using Xunit;

namespace BloomFilter.UnitTests
{
    public class MyBloomFilterTests
    {
        [Fact]
        public void Test1()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            MyBloomFilter filter = new MyBloomFilter();

            int sizeOfBitArray = filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(9586, sizeOfBitArray);
        }
    }
}
