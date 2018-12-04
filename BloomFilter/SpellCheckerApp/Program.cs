using System;
using System.Threading.Tasks;
using BloomFilter;
using BloomFilter.Utilities;

namespace SpellCheckerApp
{
    class Program
    {
        private static bool _loaded = false;
        private static SpellChecker _checker;
        private static IReader _reader;
        private static IHashFunction<string> _firstHashFunction;
        private static IHashFunction<string> _secondHashFunction;
        private static IDictionary<string> _dictionary;

        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bloom Filter Spell Checker\n");
            Command.PrintHelp();
            while (true)
            {
                Command command = new Command(Console.ReadLine());
                await Execute(command);
            }
        }

        static async Task Execute(Command command)
        {
            switch (command.Verb)
            {
                case Command.Verbs.load:
                    await LoadSpellChecker(command);
                    break;
                case Command.Verbs.check:
                    CheckWordInDictionary(command);
                    break;
                case Command.Verbs.help:
                    Command.PrintHelp();
                    break;
                case Command.Verbs.exit:
                    Environment.Exit(0);
                    break;
                case Command.Verbs.error:
                    Console.WriteLine("Sorry I couldn't understand the command, try again\n");
                    Command.PrintHelp();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        static async Task LoadSpellChecker(Command command)
        {
            if (_loaded)
            {
                Console.WriteLine("Spell checker already loaded.");
                return;
            }
            string filePath = command.Param;
            int numberOfElements;
            if (!int.TryParse(command.Param2, out numberOfElements) || numberOfElements <= 0)
            {
                Console.WriteLine("Number of elements should be an intger number greater than zero: " + command.Param2);
                return;
            }
            double falsePositiveProb;
            if (!double.TryParse(command.Param3, out falsePositiveProb) || falsePositiveProb <= 0 || falsePositiveProb >= 1)
            {
                Console.WriteLine("False positive probablity should be a number between zero and one (not inclusive): " + command.Param3);
                return;
            }
            _reader = new ReaderTxtFromFileSystem(filePath);
            try
            {
                _firstHashFunction = new HashFunctionDotNet<string>();
                _secondHashFunction = new HashFunctionJenkins<string>();
                _dictionary = new DictionaryBloomFilter<string>(numberOfElements, falsePositiveProb, _firstHashFunction, _secondHashFunction);
            }
            catch(Exception)
            {
                Console.WriteLine(string.Format("Couldn't load Bloom Filter dictionary with arguments: {0} {1}", numberOfElements, falsePositiveProb));
                return;
            }
            try
            {
                _checker = new SpellChecker(_reader, _dictionary);
                await _checker.LoadDataFromPath();
                _loaded = true;
            }
            catch(Exception)
            {
                Console.WriteLine(string.Format("Could not load spell checker from arguments {0} {1} {2}", command.Param, command.Param2, command.Param3));
                return;
            }
        }

        static void CheckWordInDictionary(Command command)
        {
            if (!_loaded)
            {
                Console.WriteLine("Spell checker not loaded yet, use -l.");
                return;
            }
            string word = command.Param;
            if(_checker.CheckWordInDictionary(word))
                Console.WriteLine("Word is in dictionary: " + word);
            else
                Console.WriteLine("Word is not in dictionary: " + word);
        }
    }
}
