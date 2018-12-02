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
        public void ComputeSizeOfBitArray_ZeroNumberOfElements_ReturnZero()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.1;
            MyBloomFilter filter = new MyBloomFilter();

            int sizeOfBitArray = filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(0, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            double falsePositiveProb = 0.1;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.0;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = -0.1;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 1.1;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            MyBloomFilter filter = new MyBloomFilter();

            int numberOfHashFunctions = filter.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(7, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroSizeOfBitArray_ReturnZero()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 0;
            MyBloomFilter filter = new MyBloomFilter();

            int numberOfHashFunctions = filter.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(0, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = -1;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            int sizeOfBitArray = 9586;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            int sizeOfBitArray = 9586;
            MyBloomFilter filter = new MyBloomFilter();

            Action act = () => filter.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
