//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDB.Services.Files
{
    internal interface IDirectoryService
    {
        long GetSize(DirectoryInfo directoryInfo);
    }
}
