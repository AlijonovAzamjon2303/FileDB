//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        List<User> GetAllUsers();
        User Update(User user);
        User Delete(User user);
    }
}
