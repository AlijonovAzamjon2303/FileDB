//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        void ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}
