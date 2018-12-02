using System;

namespace BloomFilter
{
    public class MyBloomFilter
    {
        public MyBloomFilter()
        {
        }

        public int ComputeSizeOfBitArray(int numberOfElements, double falsePositiveProb)
        {
            if (falsePositiveProb <= 0.0 || falsePositiveProb >= 1.0 || numberOfElements < 0)
                throw new ArgumentOutOfRangeException();
            return (int)Math.Ceiling(-1 * (numberOfElements * Math.Log(falsePositiveProb)) / (Math.Pow(Math.Log(2), 2)));
        }

        public int ComputeNumberOfHashFunctions(int numberOfElements, int sizeOfBitArray)
        {
            if (sizeOfBitArray < 0 || numberOfElements <= 0)
                throw new ArgumentOutOfRangeException();
            return (int)Math.Ceiling(sizeOfBitArray * Math.Log(2) / numberOfElements);
        }

        public double ComputeFalsePositiveProb(int numberOfElements, int sizeOfBitArray, int numberOfHashFunctions)
        {
            if (numberOfElements <= 0 || sizeOfBitArray <= 0 || numberOfHashFunctions <= 0)
                throw new ArgumentOutOfRangeException();
            return Math.Pow(1 - Math.Pow(1 - 1.0 / sizeOfBitArray, numberOfHashFunctions * numberOfElements), numberOfHashFunctions);
        }
    }
}
