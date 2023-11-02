using ConsoleApp;

Console.WriteLine("Hi, please enter start folder path: ");

string? startFolder = Console.ReadLine();
startFolder = startFolder?.Trim();

while (string.IsNullOrWhiteSpace(startFolder) || !Directory.Exists(startFolder))
{
    Console.WriteLine("Invalid path, please enter valid path: ");
    startFolder = Console.ReadLine();
}

var visitor = new FileSystemVisitor(startFolder, (path) =>
{
    //return true;
    return path.EndsWith(".sln", StringComparison.OrdinalIgnoreCase);
});

Console.WriteLine("The Result List: ");
visitor.Start += (sender, e) => Console.WriteLine($"Start: {e.Path}");
visitor.Finish += (sender, e) => Console.WriteLine($"Finish: {e.Path}");
visitor.FileFound += (sender, e) => Console.WriteLine($"File Found: {e.Path}");
visitor.DirectoryFound += (sender, e) => Console.WriteLine($"Directory Found: {e.Path}");
visitor.FilteredFileFound += (sender, e) => Console.WriteLine($"Filtered File Found: {e.Path}");
visitor.FilteredDirectoryFound += (sender, e) => Console.WriteLine($"Filtered Directory Found: {e.Path}");
var result = visitor.Get().ToList();


if (result.Any())
    result.ForEach(item => Console.WriteLine(item));
else
    Console.WriteLine("No Result.");

Console.ReadKey();
