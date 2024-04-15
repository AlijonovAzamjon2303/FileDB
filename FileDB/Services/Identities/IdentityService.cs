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

        private IdentityService(IStorageBroker storageBroker)
        {
            this.storagesBroker = storageBroker;
        }

        public static IdentityService GetIdentityService(IStorageBroker storageBroker)
        {
            if (instance == null)
            {
                instance = new IdentityService(storageBroker);
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storagesBroker.ReadAllUsers();

            int maxId = 0;
            foreach (User user in users)
            {
                maxId = Math.Max(maxId, user.Id);
            }

            return maxId + 1;
        }
    }
}
