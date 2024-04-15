//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------
using FileDB.Brokers.Storages;
using FileDB.Services.UserProcessing;

internal class Program
{
    private static void Main(string[] args)
    {
        IStorageBroker storageBroker =  ChooseDB();
        UserProcessingService userProcessingService = new UserProcessingService(storageBroker);

        string userChoice;
        do
        {
            PrintMenu();
            Console.Write("Enter your choice:");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter you name:");
                    string userName = Console.ReadLine();
                    userProcessingService.CreateNewUser(userName);
                    break;

                case "2":
                    {
                        Console.Clear();
                        userProcessingService.DisplayUsers();
                    }
                    break;

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to delete");
                        Console.Write("Enter id:");
                        string deleteWithIdStr = Console.ReadLine();
                        int deleteWithId = Convert.ToInt32(deleteWithIdStr);
                        userProcessingService.DeleteUser(deleteWithId);
                    }
                    break;

                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want  to edit");
                        Console.Write("Enter an id:");
                        string idStr = Console.ReadLine();
                        int id = Convert.ToInt32(idStr);
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        userProcessingService.UpdateUser(id, name);
                    }
                    break;
                case "5":
                    {
                        Console.WriteLine(userProcessingService.GetUserStorageSize());
                    }
                    break;

                case "0": break;

                default:
                    Console.WriteLine("You entered wrong input, Try again");
                    break;
            }
        }
        while (userChoice != "0");
        Console.Clear();
        Console.WriteLine("The app has been finished");
    }
    public static void PrintMenu()
    {
        Console.WriteLine("1.Create User");
        Console.WriteLine("2.Display User");
        Console.WriteLine("3.Delete User by id");
        Console.WriteLine("4.Update User by id");
        Console.WriteLine("5.Get File Size");
        Console.WriteLine("0.Exit");
    }
    public static IStorageBroker ChooseDB()
    {
        IStorageBroker broker;
        Console.WriteLine("1. .txt file");
        Console.WriteLine("2. .json file");
        Console.Write("Enter your choice : ");
        string choice = Console.ReadLine();

        broker = choice switch
        {
            "1" => new FileStorageBroker(),
            "2" => new JSONFileStorageBroker()
        };
        
        return broker;
    }
}