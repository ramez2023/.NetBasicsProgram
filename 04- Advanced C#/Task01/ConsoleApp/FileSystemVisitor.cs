namespace ConsoleApp;

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
