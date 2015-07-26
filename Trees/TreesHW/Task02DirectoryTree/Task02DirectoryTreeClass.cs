namespace Task02DirectoryTree
{
    using System;
    using System.IO;
    using System.Linq;

    public class Task02DirectoryTreeClass
    {
        public static void Main(string[] args)
        {
            const string startFolderPath = @"C:\Windows";
            Folder startFolder = new Folder(startFolderPath);
            BuildTree(startFolder);

            Console.WriteLine(GetFolderSize(startFolder));
        }

        private static void BuildTree(Folder folder)
        {
            Console.WriteLine(folder.Name);
            var files = new DirectoryInfo(folder.Name).GetFiles();
            foreach (var childFile in files)
            {
                File file = new File(childFile.FullName, childFile.Length);
                folder.Files.Add(file);
            }

            var folders = new DirectoryInfo(folder.Name).GetDirectories();
            foreach (var childFolder in folders)
            {
                Folder customFolder = new Folder(childFolder.FullName);
                folder.Folders.Add(customFolder);
                BuildTree(customFolder);
            }
        }

        public static long GetFolderSize(Folder rootFolder)
        {
            if (rootFolder == null)
            {
                return 0;
            }

            long childSum = 0;

            foreach (var folder in rootFolder.Folders)
            {
                childSum += GetFolderSize(folder);
            }

            return childSum + rootFolder.Files.Sum(f => f.Size);
        }
    }
}