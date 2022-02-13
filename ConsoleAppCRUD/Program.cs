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
            ApplicationDbContext dbContext = new ApplicationDbContext();

            UserController userController = new UserController(dbContext);

            //userController.AddUser(new User()
            //{
            //  Name = "John Doe",
            //  EmailAddress = "johndoe@gmail.com"
            //});


            var users = GetAllUsers();
            var allUsers = users.Select(u => $"{u.Name}, {u.EmailAddress}");
            foreach (var user in allUsers)
            {
                Console.WriteLine(string.Join(", ", user));
            }
        }
        public static IEnumerable<User> GetAllUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
