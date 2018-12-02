using System;
using BloomFilter.Utilities;
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

            int sizeOfBitArray = MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(9586, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroNumberOfElements_ReturnZero()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.1;

            int sizeOfBitArray = MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(0, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            double falsePositiveProb = 0.1;

            Action act = () => MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.0;

            Action act = () => MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = -0.1;

            Action act = () => MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 1.1;

            Action act = () => MyBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;

            int numberOfHashFunctions = MyBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(7, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroSizeOfBitArray_ReturnZero()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 0;

            int numberOfHashFunctions = MyBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(0, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = -1;

            Action act = () => MyBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            int sizeOfBitArray = 9586;

            Action act = () => MyBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            int sizeOfBitArray = 9586;

            Action act = () => MyBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            double falsePositiveProb = MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Equal(0.01, falsePositiveProb, 2);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroNumberOfHashFunctions_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 0;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeNumberOfHashFunctions_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = -1;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 0;
            int numberOfHashFunctions = 7;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = -1;
            int numberOfHashFunctions = 7;

            Action act = () => MyBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_WithCorrectNumberOfElementsAndFalsePositiveProb_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            MyBloomFilter<string> filter = new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.IsType<MyBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<DotNetHashFunction<string>>(filter.FirstHashFunction);
            Assert.IsType<JenkinsHashFunction<string>>(filter.SecondHashFunction);
        }

        [Fact]
        public void MyBloomFilter_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.01;

            Action act = () => new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            double falsePositiveProb = 0.01;

            Action act = () => new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_ZeroFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0;

            Action act = () => new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = -0.01;

            Action act = () => new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 1.01;

            Action act = () => new MyBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_WithFirstAndSecondHashFunction_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            IHashFunc<string> firstHashFunction = new DotNetHashFunction<string>();
            IHashFunc<string> secondHashFunction = new JenkinsHashFunction<string>();

            MyBloomFilter<string> filter = new MyBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction, secondHashFunction);

            Assert.IsType<MyBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<DotNetHashFunction<string>>(filter.FirstHashFunction);
            Assert.IsType<JenkinsHashFunction<string>>(filter.SecondHashFunction);
        }

        [Fact]
        public void MyBloomFilter_WithSecondHashFunction_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            IHashFunc<string> secondHashFunction = new JenkinsHashFunction<string>();

            MyBloomFilter<string> filter = new MyBloomFilter<string>(numberOfElements, falsePositiveProb, secondHashFunction);

            Assert.IsType<MyBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<DotNetHashFunction<string>>(filter.FirstHashFunction);
            Assert.IsType<JenkinsHashFunction<string>>(filter.SecondHashFunction);
        }
    }
}
