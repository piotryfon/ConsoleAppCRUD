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
        }

        public void UpdateUser(int id, User modifiedUser)
        {
            User user =  _dbContext.Users.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                user.Name = modifiedUser.Name;
                user.EmailAddress = modifiedUser.EmailAddress;
                int save = _dbContext.SaveChanges();
                if (save > 0)
                    Console.WriteLine("User changed");
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
    }
}
