using System;
namespace SpellCheckerApp
{
    public class Command
    {
        public Verbs Verb { get; set; }
        public string Param { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }

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
            string[] commands = command.Split(' ');
            if(command.Length != 2)
                Verb = Verbs.error;
            switch (commands[0])
            {
                case "-l":
                    if (commands.Length >= 4)
                    {
                        Verb = Verbs.load;
                        Param = commands[1];
                        Param2 = commands[2];
                        Param3 = commands[3];
                    }
                    else
                        Verb = Verbs.error;
                    break;
                case "-c":
                    if (commands.Length >= 2)
                    {
                        Verb = Verbs.check;
                        Param = commands[1];
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
                    Verb = Verbs.exit;
                    break;
            }
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Usage:\n");
            Console.WriteLine("-l <file path> <number of elements> <false positive prob>\n");
            Console.WriteLine("-c <word>: Check for a word in the dictionary. Need to load dictionary file first (-l).\n");
            Console.WriteLine("-h: Show help\n");
            Console.WriteLine("-e: Exit the application\n");
        }
    }
}
