//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Brokers.Storages;
using FileDB.Models.Users;
using FileDB.Services.Identities;
using FileDB.Services.UserServices;

namespace FileDB.Services.UserProcessing
{
    internal class UserProcessingService
    {
        private readonly IUserService userService;
        private readonly IdentityService identityService;
        public UserProcessingService(IStorageBroker storageBroker)
        {
            this.userService = new UserService(storageBroker);
            this.identityService = IdentityService.GetIdentityService(storageBroker);
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }

        public void DisplayUsers()
        {
            this.userService.ShowUsers();
        }

        public void UpdateUser(int id, string name)
        {
            User user = new User()
            {
                Id = id,
                Name = name
            };
            this.userService.Update(user);
        }

        public void DeleteUser(int id)
        {
            this.userService.Delete(id);
        }
        public long GetUserStorageSize()
        {
            long fileSize;
            string folderPath = "../../../Assets";
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            fileSize = this.CalculateFolderSize(directoryInfo);

            return fileSize;
        }

        long CalculateFolderSize(DirectoryInfo folder)
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
                size += CalculateFolderSize(subfolder);
            }

            return size;
        }
    }
}
