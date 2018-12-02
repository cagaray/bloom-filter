using System;
using Xunit;

namespace BloomFilter.UnitTests
{
    public class MyBloomFilterTests
    {
        [Fact]
        public void ComputeSizeOfBitArray_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            MyBloomFilter filter = new MyBloomFilter();

            int sizeOfBitArray = filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(9586, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroElements_ReturnZero()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.1;
            MyBloomFilter filter = new MyBloomFilter();

            int sizeOfBitArray = filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(0, sizeOfBitArray);
        }
    }
}
