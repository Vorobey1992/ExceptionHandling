using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string command = string.Empty;

            while (!command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    Console.Write("Enter a string: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input cannot be empty.");
                    }

                    Console.WriteLine($"First character: {input[0]}");

                    Console.WriteLine("Enter a command (continue, exit):");
                    command = Console.ReadLine()?.Trim() ?? string.Empty;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}