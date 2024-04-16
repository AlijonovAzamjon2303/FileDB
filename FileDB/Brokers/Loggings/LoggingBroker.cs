//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInforamation(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }
        public void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
        public void PrintUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Name}");
            }
            if (users is null)
            {
                this.LogInforamation("No users");
            }
            else
            {
                this.LogInforamation("End all users");
            }
        }
    }
}
