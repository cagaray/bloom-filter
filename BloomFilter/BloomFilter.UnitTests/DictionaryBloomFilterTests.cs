using System;
using BloomFilter.Utilities;
using Xunit;

namespace BloomFilter.UnitTests
{
    public class DictionaryBloomFilterTests
    {
        [Fact]
        public void ComputeSizeOfBitArray_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            int sizeOfBitArray = DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(9586, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroNumberOfElements_ReturnZero()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.1;

            int sizeOfBitArray = DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Equal(0, sizeOfBitArray);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            double falsePositiveProb = 0.1;

            Action act = () => DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_ZeroFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.0;

            Action act = () => DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_NegativeFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = -0.1;

            Action act = () => DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeSizeOfBitArray_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 1.1;

            Action act = () => DictionaryBloomFilter<string>.ComputeSizeOfBitArray(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;

            int numberOfHashFunctions = DictionaryBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(7, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroSizeOfBitArray_ReturnZero()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 0;

            int numberOfHashFunctions = DictionaryBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Equal(0, numberOfHashFunctions);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = -1;

            Action act = () => DictionaryBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            int sizeOfBitArray = 9586;

            Action act = () => DictionaryBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeNumberOfHashFunctions_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            int sizeOfBitArray = 9586;

            Action act = () => DictionaryBloomFilter<string>.ComputeNumberOfHashFunctions(numberOfElements, sizeOfBitArray);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_CorrectParameters_ReturnCorrectResult()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            double falsePositiveProb = DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Equal(0.01, falsePositiveProb, 2);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroNumberOfHashFunctions_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 0;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeNumberOfHashFunctions_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = -1;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            int sizeOfBitArray = 9586;
            int numberOfHashFunctions = 7;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_ZeroSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = 0;
            int numberOfHashFunctions = 7;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void ComputeFalsePositiveProb_NegativeSizeOfBitArray_ThrowException()
        {
            int numberOfElements = 1000;
            int sizeOfBitArray = -1;
            int numberOfHashFunctions = 7;

            Action act = () => DictionaryBloomFilter<string>.ComputeFalsePositiveProb(numberOfElements, sizeOfBitArray, numberOfHashFunctions);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_WithCorrectNumberOfElementsAndFalsePositiveProb_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.IsType<DictionaryBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<HashFunctionDotNet<string>>(filter.FirstHashFunction);
            Assert.IsType<HashFunctionJenkins<string>>(filter.SecondHashFunction);
        }

        [Fact]
        public void MyBloomFilter_ZeroNumberOfElements_ThrowException()
        {
            int numberOfElements = 0;
            double falsePositiveProb = 0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeNumberOfElements_ThrowException()
        {
            int numberOfElements = -1;
            double falsePositiveProb = 0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_ZeroFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = -0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 1.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_WithFirstAndSecondHashFunction_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            IHashFunction<string> firstHashFunction = new HashFunctionDotNet<string>();
            IHashFunction<string> secondHashFunction = new HashFunctionJenkins<string>();

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction, secondHashFunction);

            Assert.IsType<DictionaryBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<HashFunctionDotNet<string>>(filter.FirstHashFunction);
            Assert.IsType<HashFunctionJenkins<string>>(filter.SecondHashFunction);
        }

        [Fact]
        public void MyBloomFilter_WithSecondHashFunction_CreateInstance()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            IHashFunction<string> secondHashFunction = new HashFunctionJenkins<string>();

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, secondHashFunction);

            Assert.IsType<DictionaryBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
            Assert.IsType<HashFunctionDotNet<string>>(filter.FirstHashFunction);
            Assert.IsType<HashFunctionJenkins<string>>(filter.SecondHashFunction);
        }

        [Fact]
        public void ComputeHash_OfString_ReturnIntBetweenZeroAndSizeOfBitArrayMinusOne()
        {
            string word = "khaskjhsakjahsdhganbsjasjklakjsljkjahskhskdjhkdnbn";
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            int spacing = 0;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            int hashValue = filter.ComputeHash(word, spacing);

            Assert.InRange<int>(hashValue, 0, filter.SizeOfBitArray - 1);
        }

        [Fact]
        public void ComputeHash_SameString_ReturnSameValue()
        {
            string word1 = "foo";
            string word2 = "foo";
            int numberOfElememts = 1000;
            double falsePositivieProb = 0.01;
            int spacing = 1;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElememts, falsePositivieProb);

            int hashValue1 = filter.ComputeHash(word1, spacing);
            int hashValue2 = filter.ComputeHash(word2, spacing);

            Assert.Equal(hashValue1, hashValue2);
        }

        [Fact]
        public void IsEmpty_EmptyBloomFilter_ReturnTrue()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);

            Assert.True(filter.IsEmpty());
        }

        [Fact]
        public void IsEmpty_NonEmptyBloomFilter_ReturnFalse()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);
            string word = "foo";

            filter.AddItem(word);

            Assert.False(filter.IsEmpty());
        }

        [Fact]
        public void CheckItem_AfterInsertingSameString_ReturnTrue()
        {
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb);
            string word = "foo";

            filter.AddItem(word);
            bool found = filter.CheckItem(word);

            Assert.True(found);
        }
    }
}
