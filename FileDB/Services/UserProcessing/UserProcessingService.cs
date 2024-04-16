﻿//----------------------------------------
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

        public bool CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);

            return true;
        }

        public List<User> GetUsers() => this.userService.GetAllUsers();

        public void UpdateUser(User user)
        {
            this.userService.Update(user);
        }

        public void DeleteUser(int id)
        {
            this.userService.Delete(id);
        }
    }
}
