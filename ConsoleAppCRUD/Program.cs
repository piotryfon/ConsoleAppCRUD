using ConsoleAppCRUD.Context;
using ConsoleAppCRUD.Controllers;
using ConsoleAppCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCRUD
{
    class Program   //Entityframeworkcore.sqlserver (5.0.13)
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CosoleApp CRUD");
            Console.WriteLine("Select operation");
            Console.WriteLine("1 Display all users");
            Console.WriteLine("2 Display user by id");
            Console.WriteLine("3 Add user");
            Console.WriteLine("4 Edit user");
            Console.WriteLine("5 Delete user");
            Console.WriteLine("6 Exit");
           
            ApplicationDbContext dbContext = new ApplicationDbContext();

            UserController userController = new UserController(dbContext);

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
                    userController.GetUserById(idToGetUser);
                }
                else if (value == "3")
                {
                    Console.WriteLine("Insert user name");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Insert user email");
                    string userEmailAddress = Console.ReadLine();
                    userController.AddUser(new User()
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

                    userController.EditUser(id, new User()
                    {
                        Name = userName,
                        EmailAddress = userEmailAddress
                    });
                }
                else if (value == "5")
                {
                    Console.WriteLine("Insert user Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    userController.DeleteUser(id);
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
                Console.WriteLine("Select operation");
                value = Console.ReadLine();
            }
        }
    }
}
