using System;
using System.Collections.Generic;
using BloomFilter.Utilities;

namespace BloomFilter
{
    public class MyBloomFilter<T>
    {
        public readonly int NumberOfElements;
        public readonly double FalsePositiveProb;
        public readonly int SizeOfBitArray;
        public readonly int NumberOfHashFunctions;
        public readonly IHashFunc<T> FirstHashFunction;
        public readonly IHashFunc<T> SecondHashFunction;

        public MyBloomFilter(int numberOfElements, double falsePositiveProb) : this(numberOfElements, falsePositiveProb, null, null)
        {
        }

        public MyBloomFilter(int numberOfElements, double falsePositiveProb, IHashFunc<T> secondHashFunction) : this(numberOfElements, falsePositiveProb, null, secondHashFunction)
        {
        }

        public MyBloomFilter(int numberOfElements, double falsePositiveProb, IHashFunc<T> firstHashFunction, IHashFunc<T> secondHashFunction)
        {
            this.NumberOfElements = numberOfElements;
            this.FalsePositiveProb = falsePositiveProb;
            this.SizeOfBitArray = ComputeSizeOfBitArray(this.NumberOfElements, this.FalsePositiveProb);
            this.NumberOfHashFunctions = ComputeNumberOfHashFunctions(this.NumberOfElements, this.SizeOfBitArray);
            this.FirstHashFunction = (firstHashFunction != null) ? firstHashFunction : new DotNetHashFunction<T>();
            this.SecondHashFunction = (secondHashFunction != null) ? secondHashFunction : new JenkinsHashFunction<T>();
        }

        public static int ComputeSizeOfBitArray(int numberOfElements, double falsePositiveProb)
        {
            if (falsePositiveProb <= 0.0 || falsePositiveProb >= 1.0 || numberOfElements < 0)
                throw new ArgumentOutOfRangeException();
            return (int)Math.Ceiling(-1 * (numberOfElements * Math.Log(falsePositiveProb)) / (Math.Pow(Math.Log(2), 2)));
        }

        public static int ComputeNumberOfHashFunctions(int numberOfElements, int sizeOfBitArray)
        {
            if (sizeOfBitArray < 0 || numberOfElements <= 0)
                throw new ArgumentOutOfRangeException();
            return (int)Math.Ceiling(sizeOfBitArray * Math.Log(2) / numberOfElements);
        }

        public static double ComputeFalsePositiveProb(int numberOfElements, int sizeOfBitArray, int numberOfHashFunctions)
        {
            if (numberOfElements <= 0 || sizeOfBitArray <= 0 || numberOfHashFunctions <= 0)
                throw new ArgumentOutOfRangeException();
            return Math.Pow(1 - Math.Pow(1 - 1.0 / sizeOfBitArray, numberOfHashFunctions * numberOfElements), numberOfHashFunctions);
        }
    }
}
