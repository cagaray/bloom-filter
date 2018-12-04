using System;
using System.Collections.Generic;

namespace SpellCheckerApp
{
    public class Command
    {
        public Verbs Verb { get; set; }
        public List<string> Params { get; set; }

        public enum Verbs
        {
            load,
            check,
            help,
            exit,
            error
        }

        public Command(string command)
        {
            Params = new List<string>();
            string[] commands = command.Split(' ');
            switch (commands[0])
            {
                case "-l":
                    if (commands.Length >= 4)
                    {
                        Verb = Verbs.load;
                        Params.Add(commands[1]);
                        Params.Add(commands[2]);
                        Params.Add(commands[3]);
                    }
                    else
                        Verb = Verbs.error;
                    break;
                case "-c":
                    if (commands.Length >= 2)
                    {
                        Verb = Verbs.check;
                        Params.Add(commands[1]);
                    }
                    else
                        Verb = Verbs.error;
                    break;
                case "-h":
                    Verb = Verbs.help;
                    break;
                case "-e":
                    Verb = Verbs.exit;
                    break;
                default:
                    Verb = Verbs.error;
                    break;
            }
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Usage:\n");
            Console.WriteLine("-l <file path> <number of elements> <false positive prob>: File path with words and parameters for Bloom Filter\n");
            Console.WriteLine("-c <word>: Check for a word in the dictionary. Need to load dictionary file first (-l).\n");
            Console.WriteLine("-h: Show help\n");
            Console.WriteLine("-e: Exit the application\n");
        }
    }
}
