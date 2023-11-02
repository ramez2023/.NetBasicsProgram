using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FileSystemVisitorEventArgs : EventArgs
    {
        public string Path { get; }
        public bool Abort { get; set; }
        public bool Exclude { get; set; }

        public FileSystemVisitorEventArgs(string path, bool abort) : this(path, abort, false) { }
        public FileSystemVisitorEventArgs(string path) : this(path, false, false) { }

        public FileSystemVisitorEventArgs(string path, bool abort, bool exclude)
        {
            Path = path;
            Abort = abort;
            Exclude = exclude;
        }
    }
}
