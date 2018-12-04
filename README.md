## master
[![Build Status](https://travis-ci.com/cagaray/bloom-filter.svg?token=LKJ8qEuZfxdvLXy6TsHo&branch=master)](https://travis-ci.com/cagaray/bloom-filter)
# bloom-filter
My take on a bloom filter implementation, and a small console app to use it.

## Intro
The main idea was to complete this [exercise](http://codekata.com/kata/kata05-bloom-filters/) from CodeKata.

The solution consists on implementing a Spell Checker using a Bloom Filter to store words from a text file, and then check if words exist in the dictionary or not with a small console application.

To hash the words into the dictionary I used the Manolios and Dillinger method of combining two independent hash functions to achieve effectively k independent hash functions.

For one of the hash functions I used the [Object.GetHashCode](https://docs.microsoft.com/en-us/dotnet/api/system.object.gethashcode?view=netframework-4.7.2) method.

For the other hash function I used the Jenkins one_at_a_time hash function from the [System.Data.HashFunction.Jenkins](https://www.nuget.org/packages/System.Data.HashFunction.Jenkins/) NuGet package.

## Installation
Requires .Net Core SDK 2.1+ [Download](https://dotnet.microsoft.com/download)

To check version: `dotnet --info`

### Steps
1. Clone this repo: `git clone https://github.com/cagaray/bloom-filter.git`
2. ` cd .\BloomFilter\`
3. `dotnet restore`
4. `cd .\SpellCheckerApp\`
5. `dotnet run`

## Use
When first run the console application, you should see the following screen:

![Initial screen](https://i.imgur.com/dn9ozgr.png)

Possible commands:

-l: Loads a Bloom Filter based dictionary with the words in a file.

Arguments:

* \<file path>: Full path of the txt file containing the words to load on the dictionary. Each line should contain one word.
* \<number of elements>: Integer numbers representing the number of elements to hold on the dictionary (can be an approximation or an arbitrarily large number).
* \<false positive prob>: Probability of getting a false positive when looking for a word. Should be a decimal number greater than zero and less than one (not inclusive).

-c: Check for a word in an already loaded dictionary. If the dictionary hasn't been loaded yet, it will ask to load it first.

Arguments:

* \<word>: Word to look for in the dictionary.

-h: Will print help screen (same as initial).

-e: Will exit the application.

### Example
Loading dictionary:

![Loading dictionary](https://i.imgur.com/I6KnB0D.png)

Checking if a word is in the dictionary:

![Checking words](https://i.imgur.com/3V6h4R8.png)

## Future work
Optional part of Kata 05:

```
Try generating random 5-character words and feeding them in to your spell checker. For each word that it says it OK, look it up in the original dictionary. See how many false positives you get.
```

## References
https://en.wikipedia.org/wiki/Bloom_filter

https://www.kdnuggets.com/2016/08/gentle-introduction-bloom-filter.html

https://www.geeksforgeeks.org/bloom-filters-introduction-and-python-implementation/

https://llimllib.github.io/bloomfilter-tutorial/

http://www.ccs.neu.edu/home/pete/research/bloom-filters-verification.html

https://en.wikipedia.org/wiki/Jenkins_hash_function
