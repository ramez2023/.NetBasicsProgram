/*
Create a class FileSystemVisitor, which allows you to traverse a tree of folders on the filesystem from the pre-defined folder. 

Note: Please discuss with the mentor which presentation layer you will use before implementation (console or desktop application). 

FileSystemVisitor class should implement the following functionality: 
Return all found files and folders in the form of a linear sequence, for which implement your own iterator (using the yield operator if possible). 
Provide the ability to set an algorithm for filtering found files and folders at the time of creating an instance of FileSystemVisitor (via a special overloaded constructor). 
The algorithm must be specified as a delegate/lambda. 

*/
namespace Task01;

public class FileSystemVisitor
{
    private readonly string _rootFolder;
    private readonly Func<string, bool> _filter;

    public FileSystemVisitor(string rootFolder)
    {
        _rootFolder = rootFolder;
        _filter = (path) => true; // Default filter, includes all items.
    }

    public FileSystemVisitor(string rootFolder, Func<string, bool> filter)
    {
        _rootFolder = rootFolder;
        _filter = filter;
    }

    public IEnumerable<string> Get()
    {
        return Get(_rootFolder);
    }

    private IEnumerable<string> Get(string folder)
    {
        foreach (var file in Directory.GetFiles(folder).Where(_filter))
        {
            yield return file;
        }

        foreach (var subfolder in Directory.GetDirectories(folder))
        {
            if (_filter(subfolder))
                yield return subfolder;

            foreach (var item in Get(subfolder))
            {
                yield return item;
            }
        }
    }
}
