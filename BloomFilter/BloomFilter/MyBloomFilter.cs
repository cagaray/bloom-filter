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
            if (falsePositiveProb <= 0.0 || falsePositiveProb >= 1.0)
                throw new ArgumentOutOfRangeException();
            int sizeOfBitArray = (int)Math.Ceiling(-1 * (numberOfElements * Math.Log(falsePositiveProb)) / (Math.Pow(Math.Log(2), 2)));
            return sizeOfBitArray;
        }
    }
}
