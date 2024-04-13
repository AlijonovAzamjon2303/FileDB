//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

namespace FileDB.Brokers.Storages
{
    internal static class StorageFactory
    {
       public static IStorageBroker CreateStorage(string name)
       {
            if (name == "txt") return new FileStorageBroker();
            
            return new JSONFileStorageBroker();
       }
    }
}
