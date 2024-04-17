//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Brokers.Storages
{
    internal interface IStorageBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        User UpdateUser(User user);
        User DeleteUser(User user);
    }
}
