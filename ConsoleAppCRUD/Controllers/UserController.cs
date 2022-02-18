using ConsoleAppCRUD.Context;
using ConsoleAppCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCRUD.Controllers
{
    class UserController
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            var insertedUser = _dbContext.Add(user);
            if (insertedUser != null)
                _dbContext.SaveChanges();
                Console.WriteLine("User added");
        }

        public void EditUser(int id, User modifiedUser)
        {
            User user = _dbContext.Users.SingleOrDefault(d => d.Id == id);
            if(user == null)
            {
                Console.WriteLine("User not found");
            }
            else
            {
                try
                {
                    user.Name = modifiedUser.Name;
                    user.EmailAddress = modifiedUser.EmailAddress;
                    int save = _dbContext.SaveChanges();
                    if (save > 0)
                        Console.WriteLine("User changed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
          
        }

        public void DeleteUser(int id)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                Console.WriteLine("User not found.");

            try
            {
                _dbContext.Remove(user);
                int removeUser = _dbContext.SaveChanges();
                if (removeUser > 0)
                    Console.WriteLine($"User {id} removed successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void GetUserById(int Id)
        {
            var userById = _dbContext.Users.FirstOrDefault(u => u.Id == Id);

            if(userById != default)
                Console.WriteLine($"{userById.Name} {userById.EmailAddress}");
            else Console.WriteLine("User not found");
        }
    }
}
