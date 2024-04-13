//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;
using System.Text.Json;

namespace FileDB.Brokers.Storages
{
    internal class JSONFileStorageBroker : IStorageBroker
    {
        private const string FILEPATH = "../../../Assets/Users.json";
        public JSONFileStorageBroker()
        {
            EnsureFileExists();
        }
        public User AddUser(User user)
        {
            string jsonText = File.ReadAllText(FILEPATH);
            List<User> users = ReadAllUsers();
            users.Add(user);
            jsonText = JsonSerializer.Serialize(users);
            File.WriteAllText(FILEPATH, jsonText);

            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ReadAllUsers()
        {
            var userJson = File.ReadAllText(FILEPATH);
            List<User> users = JsonSerializer.Deserialize<List<User>>(userJson);

            return users;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        private void EnsureFileExists()
        {
            bool exists = File.Exists(FILEPATH);
            if(!exists)
            {
                File.Create(FILEPATH).Close();
            }
        }
    }
}
