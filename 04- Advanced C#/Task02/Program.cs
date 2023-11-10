/*

Task 2: 

For solution from Task 1 add the following functionality: 

1. Generate notifications (via the ‘event’ mechanism) about the stages of their work. 
   In particular, the following events must be implemented (event names can be anything, it is important to follow the naming convention): 
        - Start and Finish (for the beginning and end of the search). 
        - FileFound / DirectoryFound for all found files and folders before filtering, 
        - FilteredFileFound / FilteredDirectoryFound for filtered files and folders. 

These events should allow (by setting special flags in the parameter): 
         - Abort search 
         - Exclude files/folders from the final list 


*/

using Task02;

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
    return true;
    //return path.EndsWith(".sln", StringComparison.OrdinalIgnoreCase);
});


visitor.Start += (sender, e) => Console.WriteLine($"Start: {e.Path}");
visitor.Finish += (sender, e) => Console.WriteLine($"Finish: {e.Path}");
visitor.FileFound += (sender, e) => Console.WriteLine($"File Found: {e.Path}");
visitor.DirectoryFound += (sender, e) => Console.WriteLine($"Directory Found: {e.Path}");
visitor.FilteredFileFound += (sender, e) => Console.WriteLine($"Filtered File Found: {e.Path}");
visitor.FilteredDirectoryFound += (sender, e) => Console.WriteLine($"Filtered Directory Found: {e.Path}");


Console.WriteLine("\n\n\n");
Console.WriteLine("The Result List: ");
var result = visitor.Get().ToList();
if (result.Any())
    result.ForEach(item => Console.WriteLine(item));
else
    Console.WriteLine("No Result.");

Console.ReadKey();
