﻿//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Services.UserProcessing
{
    internal interface IUserProcessingService
    {
        User AddUser(User user);
        List<User> GetUsers();
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
