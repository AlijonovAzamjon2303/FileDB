//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;
using System.Text.Json;
using System.Collections.Generic;

namespace FileDB.Brokers.Storages
{
    internal class JSONFileStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Assets/Users.json";
        private JsonSerializerOptions options;
        public JSONFileStorageBroker()
        {
            EnsureFileExists();
            options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.WriteIndented = true;
        }
        public User AddUser(User user)
        {
            List<User> users = this.ReadAllUsers();
            users.Add(user);

            string jsonUsers = JsonSerializer.Serialize(users, options);
            File.WriteAllText(FILEPATH, jsonUsers);

            return user;
        }

        public bool DeleteUser(int id)
        {
            List<User> users = this.ReadAllUsers();
            int index = -1;
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    index = i;
                }
            }

            users.RemoveAt(index);
            this.WriteUsers(users);

            return true;
        }

        public List<User> ReadAllUsers()
        {
            string userJson = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(userJson, options);

            return users;
        }

        public User UpdateUser(User user)
        {
            List<User> users = this.ReadAllUsers();
            for(int i = 0; i < users.Count;i++)
            {
                if (users[i].Id == user.Id)
                {
                    users[i] = user;
                    break;
                }
            }

            this.WriteUsers(users);
            
            return user;
        }
        private void EnsureFileExists()
        {
            bool exists = File.Exists(FILEPATH);
            if(!exists)
            {
                File.Create(FILEPATH).Close();
                File.AppendAllText(FILEPATH, "[]");
            }
        }

        private void WriteUsers(List<User> users)
        {
            string jsonUsers = JsonSerializer.Serialize(users, options);

            File.WriteAllText(FILEPATH, jsonUsers);
        }
    }
}
