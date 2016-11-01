using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AvlTree
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
                return;
            IEnumerable<string> inputs;
            try
            {
                inputs = File.ReadAllText(args[0]).Split(' ');
            }
            catch (Exception e)
            {
                WriteErrorMessage("    " + e.Message);
                return;
            }

            var tree = new AvlTree();
            InitialPrint(inputs, ref tree);

            while (true)
            {
                Console.WriteLine();
                WritePrompt("[B] - break  [I] - insert  [D] - delete  > ");
                var key = Console.ReadKey().KeyChar;
                if (key.ToString().ToUpper() == "B") break;
                else if (key.ToString().ToUpper() == "I") Insert(ref tree);
                else if (key.ToString().ToUpper() == "D") Delete(ref tree);
                else WriteErrorMessage("\nUnrecognized option.");
            }
            Console.WriteLine();
        }

        private static void InitialPrint(IEnumerable<string> inputs, ref AvlTree tree)
        {
            var enumerable = inputs as IList<string> ?? inputs.ToList();
            WritePrompt("Inputs: \n    " + string.Join(", ", enumerable));
            Console.WriteLine();

            WritePrompt("AVL tree:\n");
            foreach (var input in enumerable)
            {
                int num;
                if (int.TryParse(input, out num)) tree.Insert(num);
            }

            tree.Print();
        }

        private static void Insert(ref AvlTree tree)
        {
            WritePrompt("\n    Insert a number: ");
            var key = Console.ReadLine();
            int number;
            if (!int.TryParse(key, out number))
            {
                WriteErrorMessage("\n    Invalid number inserted.");
                return;
            }
            Console.WriteLine();
            tree.Insert(number);
            tree.Print();
        }

        private static void Delete(ref AvlTree tree)
        {
            WritePrompt("\n    Delete a node: ");
            var key = Console.ReadLine();
            int number;
            if (!int.TryParse(key, out number))
            {
                WriteErrorMessage("\n    Invalid number inserted.");
                return;
            }
            Console.WriteLine();
            tree.Delete(number);
            tree.Print();
        }

        private static void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WritePrompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
