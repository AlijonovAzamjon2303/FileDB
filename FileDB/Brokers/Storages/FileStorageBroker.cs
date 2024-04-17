//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string filePath = "../../../Assets/Users.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public User AddUser(User user)
        {
            string userLine = $"{user.Id}*{user.Name}\n";
            File.AppendAllText(filePath, userLine);

            return user;
        }
        public User UpdateUser(User user)
        {
            List<User> users = ReadAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == user.Id)
                {
                    users[i] = user;
                    break;
                }
            }
            File.WriteAllText(filePath, string.Empty);
            foreach (User user1 in users)
            {
                AddUser(user1);
            }

            return user;
        }
        public List<User> ReadAllUsers()
        {
            string[] userLines = File.ReadAllLines(filePath);
            List<User> users = new List<User>();

            foreach (string userLine in userLines)
            {
                string[] userProperties = userLine.Split("*");
                User user = new User
                {
                    Id = Convert.ToInt32(userProperties[0]),
                    Name = userProperties[1],
                };
                users.Add(user);
            }

            return users;
        }
        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(filePath);
            if (fileExists is false)
            {
                File.Create(filePath).Close();
            }
        }

        public User DeleteUser(User user)
        {
            List<User> users = this.ReadAllUsers();
            File.WriteAllText(filePath, string.Empty);
            int index = -1;
            for(int i = 0; i < users.Count; i++) 
            {
                if (users[i].Id == user.Id)
                {
                    index = i;
                }
            }
            users.RemoveAt(index);

            for (int i = 0; i < users.Count; i++)
            {
                this.AddUser(users[i]);
            }

            return user;
        }
    }
}
