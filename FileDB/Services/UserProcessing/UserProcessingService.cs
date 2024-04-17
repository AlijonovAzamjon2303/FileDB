//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Brokers.Storages;
using FileDB.Models.Users;
using FileDB.Services.Identities;
using FileDB.Services.UserServices;

namespace FileDB.Services.UserProcessing
{
    internal class UserProcessingService : IUserProcessingService
    {
        private readonly IUserService userService;
        private readonly IdentityService identityService;
        public UserProcessingService(IStorageBroker storageBroker)
        {
            this.userService = new UserService(storageBroker);
            this.identityService = IdentityService.GetIdentityService(storageBroker);
        }

        public User AddUser(User user)
        {
            user.Id = this.identityService.GetNewId();
            this.userService.AddUser(user);

            return user;
        }

        public List<User> GetUsers() => this.userService.GetAllUsers();

        public User UpdateUser(User user)
        {
            this.userService.Update(user);

            return user;
        }

        public User DeleteUser(int id)
        {
            List<User> users = this.userService.GetAllUsers();
            User needDelete = new User();
            foreach (User user in users) 
            {
                if(user.Id == id)
                {
                    needDelete = user;
                }
            }

            this.userService.Delete(needDelete);

            return needDelete;
        }
    }
}
