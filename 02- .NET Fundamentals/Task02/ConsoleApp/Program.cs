// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hi, please enter your name: ");

string? username = Console.ReadLine();

while (string.IsNullOrWhiteSpace(username))
{
    Console.WriteLine("Empty string, please enter valid name: ");
    username = Console.ReadLine();
}

Console.WriteLine($"Hello, {username}");
