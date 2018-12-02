﻿using System;

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

        public int ComputeNumberOfHashFunctions(int numberOfElements, int sizeOfBitArray)
        {
            if (sizeOfBitArray < 0 || numberOfElements <= 0)
                throw new ArgumentOutOfRangeException();
            int numberOfHashFunctions = (int)Math.Ceiling(sizeOfBitArray * Math.Log(2) / numberOfElements);
            return numberOfHashFunctions;
        }
    }
}
