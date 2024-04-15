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
        public void ShowUsers()
        {
            List<User> users = this.storageBroker.ReadAllUsers();
            if(users == null)
            {
                Console.WriteLine("Hali hech kim qo'shilmagan");
            }
            foreach (User user in users)
            {
                this.loggingBroker.LogInforamation($"{user.Id}. {user.Name}");
            }
            this.loggingBroker.LogInforamation("===End of users===");
        }
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
        public void DeleteUser(int id)
        {
            List<User> users = this.storageBroker.ReadAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != null && users[i].Id == id)
                {
                    this.storageBroker.DeleteUser(id);
                    this.loggingBroker.LogInforamation($"User with ID {id} deleted successfully.");
                    return;
                }
            }
            this.loggingBroker.LogError($"User with ID {id} not found.");
        }
        public void Update(User user)
        {
            if (user is null)
            {
                this.loggingBroker.LogError("Your user is empty");
                return;
            }

            if (user.Id == 0 || String.IsNullOrEmpty(user.Name))
            {
                this.loggingBroker.LogError("Your user is invalid");
            }

            this.storageBroker.UpdateUser(user);
        }
        public void Delete(int id)
        {
            this.storageBroker.DeleteUser(id);
        }
    }
}
