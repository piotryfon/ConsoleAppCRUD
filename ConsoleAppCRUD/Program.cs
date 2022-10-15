using ConsoleAppCRUD.Context;
using ConsoleAppCRUD.Controllers;
using ConsoleAppCRUD.Entities;
using ConsoleAppCRUD.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppCRUD
{
    class Program //Entityframeworkcore.sqlserver (5.0.13)
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("CosoleApp CRUD");

            ApplicationDbContext context = new ApplicationDbContext();
            IService service = new Service(context);
            UserController userController = new UserController(service);

            SelectOperations();

            string value = Console.ReadLine();
            while (true)
            {
                if (value == "1")
                {
                    var users = userController.GetAllUsers();
                    var allUsers = users.Select(u => $"{u.Id} {u.Name}, {u.EmailAddress}");
                    foreach (var user in allUsers)
                    {
                        Console.WriteLine(string.Join(", ", user));
                    }
                }
                else if (value == "2")
                {
                    Console.WriteLine("Insert id");
                    int idToGetUser = Convert.ToInt32(Console.ReadLine());
                    await userController.GetUserById(idToGetUser);
                }
                else if (value == "3")
                {
                    Console.WriteLine("Insert user name");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Insert user email");
                    string userEmailAddress = Console.ReadLine();
                    await userController.AddUser(new User()
                    {
                        Name = userName,
                        EmailAddress = userEmailAddress,
                    });
                }
                else if (value == "4")
                {
                    Console.WriteLine("Insert user Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insert user name");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Insert user email");
                    string userEmailAddress = Console.ReadLine();

                    await userController.EditUser(id, new User()
                    {
                        Name = userName,
                        EmailAddress = userEmailAddress
                    });
                }
                else if (value == "5")
                {
                    Console.WriteLine("Insert user Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    await userController.DeleteUser(id);
                }
                else if (value == "6")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
                Console.WriteLine("====================");
                SelectOperations();
                value = Console.ReadLine();
            }
        }
        public static void SelectOperations()
        {
            Console.WriteLine("Select operation");
            Console.WriteLine("1 Display all users");
            Console.WriteLine("2 Display user by id");
            Console.WriteLine("3 Add user");
            Console.WriteLine("4 Edit user");
            Console.WriteLine("5 Delete user");
            Console.WriteLine("6 Exit");
        }
    }
}
