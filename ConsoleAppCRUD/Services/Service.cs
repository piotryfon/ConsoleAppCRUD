using ConsoleAppCRUD.Context;
using ConsoleAppCRUD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppCRUD.Services
{
    interface IService
    {
        public Task AddUser(User user);
        public Task EditUser(int id, User modifiedUser);
        public Task DeleteUser(int id);
        public IEnumerable<User> GetAllUsers();
        public Task GetUserById(int Id);
    }
    internal class Service : IService
    {
        private readonly ApplicationDbContext _dbContext;
        public Service(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(User user)
        {
            _dbContext.Add(user);

            int newUser = await _dbContext.SaveChangesAsync();
            if (newUser > 0)
                Console.WriteLine("User added");
        }
        public async Task EditUser(int id, User modifiedUser)
        {
            User user = await _dbContext.Users.SingleOrDefaultAsync(d => d.Id == id);
            if (user == null)
            {
                Console.WriteLine("User not found");
            }
            else
            {
                try
                {
                    user.Name = modifiedUser.Name;
                    user.EmailAddress = modifiedUser.EmailAddress;
                    int editedUser = await _dbContext.SaveChangesAsync();
                    if (editedUser > 0)
                        Console.WriteLine("User changed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public async Task DeleteUser(int id)
        {
            User user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
                Console.WriteLine("User not found.");

            try
            {
                _dbContext.Remove(user);
                int removeUser = await _dbContext.SaveChangesAsync();
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
        public async Task GetUserById(int Id)
        {
            var userById = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (userById != default)
                Console.WriteLine($"{userById.Name} {userById.EmailAddress}");
            else Console.WriteLine("User not found");
        }
    }
}

