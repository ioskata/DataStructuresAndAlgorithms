namespace Task02DirectoryTree
{
    using System.Collections.Generic;

    public class Folder
    {
        private ICollection<File> files;
        private ICollection<Folder> folders;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new HashSet<File>();
            this.Folders = new HashSet<Folder>();
        }

        public string Name { get; set; }

        public ICollection<File> Files
        {
            get {return this.files; }
            set { this.files = value; }
        }

        public ICollection<Folder> Folders
        {
            get { return this.folders; }
            set { this.folders = value; }
        }
    }
}
