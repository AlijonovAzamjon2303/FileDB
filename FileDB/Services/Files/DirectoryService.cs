//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDB.Services.Files
{
    internal class DirectoryService : IDirectoryService
    {
        public DirectoryService() { }
        public long GetSize(DirectoryInfo folder)
        {
            long size = 0;

            FileInfo[] files = folder.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] subfolders = folder.GetDirectories();
            foreach (DirectoryInfo subfolder in subfolders)
            {
                size += GetSize(subfolder);
            }

            return size;
        }
    }
}
