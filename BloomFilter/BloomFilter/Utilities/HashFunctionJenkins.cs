﻿using System.Data.HashFunction;
using System.Data.HashFunction.Jenkins;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BloomFilter.Utilities
{
    public class HashFunctionJenkins<T> : IHashFunction<T>
    {
        private IJenkinsOneAtATime _jenkinsOneAtATime;

        public HashFunctionJenkins()
        {
            this._jenkinsOneAtATime = JenkinsOneAtATimeFactory.Instance.Create();
        }

        public int ComputeHash(T value)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, value);
            byte[] result = stream.ToArray();
            IHashValue hashValue = this._jenkinsOneAtATime.ComputeHash(result);
            return int.Parse(hashValue.AsHexString(), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
