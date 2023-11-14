/*

Task 01 :
Open Program class under Task1 project and implement a method that prints the first character of each entered input line. 
Use exception handling mechanism to validate input for empty string.   

 */

using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            Console.WriteLine("Enter lines of text (press 'q' to exit):");

            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                    break;

                try
                {
                    PrintFirstCharacter(input);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void PrintFirstCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            char firstChar = input[0];
            Console.WriteLine($"First character: {firstChar}");
        }
    }
}