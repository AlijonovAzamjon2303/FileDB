//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Brokers.Loggings;
using FileDB.Brokers.Storages;
using FileDB.Models.Users;

namespace FileDB.Services.UserServices
{
    internal class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = new LoggingBroker();
        }
        public User AddUser(User user)
        {
            return user is null
                ? CreateAndLogInvalidUser()
                : ValidateAndAddUser(user);
        }
        public List<User> GetAllUsers() => this.storageBroker.ReadAllUsers();
        private User CreateAndLogInvalidUser()
        {
            this.loggingBroker.LogError("User is invalid");
            return new User();
        }
        private User ValidateAndAddUser(User user)
        {
            if (user.Id is 0 || String.IsNullOrWhiteSpace(user.Name))
            {
                this.loggingBroker.LogError("User details missing.");
                return new User();
            }
            else
            {
                this.loggingBroker.LogInforamation("User is created successfully");
                return this.storageBroker.AddUser(user);
            }
        }
        public User Update(User user)
        {
            if (user is null)
            {
                this.loggingBroker.LogError("Your user is empty");
                return new User();
            }

            if (user.Id == 0 || String.IsNullOrEmpty(user.Name))
            {
                this.loggingBroker.LogError("Your user is invalid");
                return new User();
            }

            try
            {
                this.storageBroker.UpdateUser(user);
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError($"{exception.Message}");
            }

            return user;
        }
        public User Delete(User user)
        {
            this.storageBroker.DeleteUser(user);
            
            return user;
        }
    }
}
