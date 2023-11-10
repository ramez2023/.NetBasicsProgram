using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class FileSystemVisitorEventArgs : EventArgs
    {
        public string Path { get; }
        public bool Abort { get; set; }
        public bool Exclude { get; set; }

        public FileSystemVisitorEventArgs(string path, bool abort) : this(path, abort, false) { }

        public FileSystemVisitorEventArgs(string path, bool abort = false, bool exclude = false)
        {
            Path = path;
            Abort = abort;
            Exclude = exclude;
        }
    }
}
