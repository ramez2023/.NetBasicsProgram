using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using Task02;

[TestClass]
public class FileSystemVisitorTests
{
    private static string _testRootFolder;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        _testRootFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testRootFolder);

        // Create some test files and folders
        File.WriteAllText(Path.Combine(_testRootFolder, "file1.txt"), "Test content 1");
        File.WriteAllText(Path.Combine(_testRootFolder, "file2.txt"), "Test content 2");
        Directory.CreateDirectory(Path.Combine(_testRootFolder, "subfolder1"));
        Directory.CreateDirectory(Path.Combine(_testRootFolder, "subfolder2"));
    }


    [TestMethod]
    public void Get_ReturnsAllFilesAndFolders_WhenNoFilterIsSpecified()
    {
        // Arrange
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(4, result.Count()); // Adjust based on the actual number of files and folders
    }

    [TestMethod]
    public void Get_ReturnsFilteredFilesAndFolders_WhenFilterIsSpecified()
    {
        // Arrange
        var filter = new Func<string, bool>(path => Path.GetFileName(path).StartsWith("file"));
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder, filter);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(2, result.Count()); // Adjust based on the actual number of files matching the filter
    }

    [TestMethod]
    public void Get_ReturnsNothing_WhenFilterExcludesAllItems()
    {
        // Arrange
        var filter = new Func<string, bool>(path => false);
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder, filter);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void Get_ReturnsFilesOnly_WhenFilterExcludesFolders()
    {
        // Arrange
        var filter = new Func<string, bool>(path => File.Exists(path));
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder, filter);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(2, result.Count()); // Adjust based on the actual number of files
    }

    [TestMethod]
    public void Get_ReturnsFoldersOnly_WhenFilterExcludesFiles()
    {
        // Arrange
        var filter = new Func<string, bool>(path => Directory.Exists(path));
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder, filter);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(2, result.Count()); // Adjust based on the actual number of folders
    }

    [TestMethod]
    public void Get_ReturnsNothing_WhenRootFolderIsEmpty()
    {
        // Arrange
        var emptyFolder = Path.Combine(Path.GetTempPath(), "EmptyFolder");
        Directory.CreateDirectory(emptyFolder);
        var fileSystemVisitor = new FileSystemVisitor(emptyFolder);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void Get_ReturnsCorrectNestedFilesAndFolders_WhenFilterIsComplex()
    {
        // Arrange
        var filter = new Func<string, bool>(path =>
            (File.Exists(path) && Path.GetFileName(path).StartsWith("file")) ||
            (Directory.Exists(path) && Path.GetFileName(path).StartsWith("subfolder")));
        var fileSystemVisitor = new FileSystemVisitor(_testRootFolder, filter);

        // Act
        var result = fileSystemVisitor.Get();

        // Assert
        Assert.AreEqual(4, result.Count()); // Adjust based on the actual number of items matching the filter
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // Clean up the test folders and files
        Directory.Delete(_testRootFolder, true);
    }
}
