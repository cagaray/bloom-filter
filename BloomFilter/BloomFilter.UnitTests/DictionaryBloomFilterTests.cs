using System;
using BloomFilter.Utilities;
using Moq;
using Xunit;

namespace BloomFilter.UnitTests
{
    public class DictionaryBloomFilterTests
    {
        [Fact]
        public void MyBloomFilter_WithCorrectNumberOfElementsAndFalsePositiveProb_CreateInstance()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.IsType<DictionaryBloomFilter<string>>(filter);
            Assert.Equal(1000, filter.NumberOfElements);
            Assert.Equal(0.01, filter.FalsePositiveProb, 2);
            Assert.Equal(9586, filter.SizeOfBitArray);
            Assert.Equal(7, filter.NumberOfHashFunctions);
        }

        [Fact]
        public void MyBloomFilter_ZeroNumberOfElements_ThrowException()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 0;
            double falsePositiveProb = 0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeNumberOfElements_ThrowException()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = -1;
            double falsePositiveProb = 0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_ZeroFalsePositiveProb_ThrowException()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 0;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_NegativeFalsePositiveProb_ThrowException()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = -0.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void MyBloomFilter_GreaterThanOneFalsePositiveProb_ThrowException()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 1.01;

            Action act = () => new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void IsEmpty_EmptyBloomFilter_ReturnTrue()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;

            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);

            Assert.True(filter.IsEmpty());
        }

        [Fact]
        public void IsEmpty_NonEmptyBloomFilter_ReturnFalse()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);
            string word = "foo";

            filter.AddItem(word);

            Assert.False(filter.IsEmpty());
        }

        [Fact]
        public void CheckItem_AfterInsertingSameString_ReturnTrue()
        {
            var firstHashFunction = new Mock<IHashFunction<string>>();
            firstHashFunction.Setup(f => f.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            var secondHashFunction = new Mock<IHashFunction<string>>();
            secondHashFunction.Setup(s => s.ComputeHash(It.IsAny<string>())).Returns(It.IsAny<int>());
            int numberOfElements = 1000;
            double falsePositiveProb = 0.01;
            DictionaryBloomFilter<string> filter = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, firstHashFunction.Object, secondHashFunction.Object);
            string word = "foo";

            filter.AddItem(word);
            bool found = filter.CheckItem(word);

            Assert.True(found);
        }
    }
}
