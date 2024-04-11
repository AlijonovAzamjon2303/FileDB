//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Brokers.Storages;
using FileDB.Models.Users;

namespace FileDB.Services.Identities
{
    internal class IdentityService
    {
        private static IdentityService instance;
        private readonly IStorageBroker storagesBroker;

        private IdentityService()
        {
            this.storagesBroker = new FileStorageBroker();
        }

        public static IdentityService GetIdentityService()
        {
            if (instance == null)
            {
                instance = new IdentityService();
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storagesBroker.ReadAllUsers();

            return users.Count is not 0
                ? IncrementListUsersId(users)
                : 1;
        }

        private static int IncrementListUsersId(List<User> users)
        {
            return users[users.Count - 1].Id + 1;

        }
    }
}
