using Task01;

Console.WriteLine("Hi, please enter start folder path: ");

string? startFolder = Console.ReadLine();

while (string.IsNullOrWhiteSpace(startFolder) || !Directory.Exists(startFolder))
{
    Console.WriteLine("Invalid path, please enter valid path: ");
    startFolder = Console.ReadLine();
}

var visitor = new FileSystemVisitor(startFolder, (path) =>
{
    //return true;
    return path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase);
});

Console.WriteLine("The Result List: ");
var result = visitor.Get().ToList();

if (result.Any())
    result.ForEach(item => Console.WriteLine(item));
else
    Console.WriteLine("No Result.");