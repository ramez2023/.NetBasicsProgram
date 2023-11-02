namespace ConsoleApp
{
    public class FileSystemVisitor
    {
        private readonly string _rootFolder;
        private readonly Func<string, bool> _filter;

        public event EventHandler<FileSystemVisitorEventArgs> Start;
        public event EventHandler<FileSystemVisitorEventArgs> Finish;
        public event EventHandler<FileSystemVisitorEventArgs> FileFound;
        public event EventHandler<FileSystemVisitorEventArgs> DirectoryFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredDirectoryFound;

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
            OnStart();

            foreach (var item in Get(_rootFolder))
            {
                yield return item;
            }

            OnFinish();
        }

        private IEnumerable<string> Get(string folder)
        {
            foreach (var file in Directory.GetFiles(folder))
            {
                var args = new FileSystemVisitorEventArgs(_rootFolder, false, true);
                OnFileFound(args);

                if (!args.Abort && _filter(file))
                {
                    OnFilteredFileFound(args);

                    if (!args.Exclude)
                    {
                        yield return file;
                    }
                }
            }

            foreach (var subfolder in Directory.GetDirectories(folder))
            {
                var args = new FileSystemVisitorEventArgs(_rootFolder, false, true);
                OnDirectoryFound(args);

                if (!args.Abort && _filter(subfolder))
                {
                    OnFilteredDirectoryFound(args);

                    if (!args.Exclude)
                    {
                        yield return subfolder;
                    }
                }

                foreach (var item in Get(subfolder))
                {
                    yield return item;
                }
            }
        }



        protected virtual void OnStart()
        {
            EventHandler<FileSystemVisitorEventArgs> handler = Start;
            if (handler != null)
                handler(this, new FileSystemVisitorEventArgs(_rootFolder));
        }

        protected virtual void OnFinish()
        {
            Finish?.Invoke(this, new FileSystemVisitorEventArgs(_rootFolder));
        }

        protected virtual void OnFileFound(FileSystemVisitorEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        protected virtual void OnDirectoryFound(FileSystemVisitorEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredFileFound(FileSystemVisitorEventArgs e)
        {
            FilteredFileFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredDirectoryFound(FileSystemVisitorEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(this, e);
        }

    }
}
