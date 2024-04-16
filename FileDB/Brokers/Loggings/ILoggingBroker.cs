//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDB.Models.Users;

namespace FileDB.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
        void PrintUsers(List<User> users);
    }
}
