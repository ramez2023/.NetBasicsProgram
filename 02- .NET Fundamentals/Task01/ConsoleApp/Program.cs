// See https://aka.ms/new-console-template for more information
using HelperClassLibrary;

Console.WriteLine("Hi, please enter your name: ");

string? username = Console.ReadLine();

while (string.IsNullOrWhiteSpace(username))
{
    Console.WriteLine(string.Concat(Helper.GetErrorMessage(), ": "));
    username = Console.ReadLine();
}

Console.WriteLine(Helper.GetRichName(username));
